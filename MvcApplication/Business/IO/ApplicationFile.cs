using System;
using System.Globalization;
using System.IO.Abstractions;
using System.Linq;
using System.Security.Principal;
using MvcApplication.Business.Configuration;
using MvcApplication.Business.Security.Principal;
using MvcApplication.Business.Security.Principal.Extensions;

namespace MvcApplication.Business.IO
{
	public class ApplicationFile : IApplicationFile
	{
		#region Fields

		private Lazy<string> _path;

		#endregion

		#region Constructors

		public ApplicationFile(IApplicationDomain applicationDomain, IConfigurationManager configurationManager, IEnvironment environment, IFileSystem fileSystem, IPrincipalContext principalContext)
		{
			if(applicationDomain == null)
				throw new ArgumentNullException(nameof(applicationDomain));

			if(configurationManager == null)
				throw new ArgumentNullException(nameof(configurationManager));

			if(environment == null)
				throw new ArgumentNullException(nameof(environment));

			if(fileSystem == null)
				throw new ArgumentNullException(nameof(fileSystem));

			if(principalContext == null)
				throw new ArgumentNullException(nameof(principalContext));

			this.ApplicationDomain = applicationDomain;
			this.ConfigurationManager = configurationManager;
			this.Environment = environment;
			this.FileSystem = fileSystem;
			this.PrincipalContext = principalContext;
		}

		#endregion

		#region Properties

		protected internal virtual IApplicationDomain ApplicationDomain { get; }
		protected internal virtual IConfigurationManager ConfigurationManager { get; }

		public virtual string Content
		{
			get
			{
				if(this.ContentInternal == null)
					this.ContentInternal = new Lazy<string>(() =>
					{
						using(this.PrincipalContext.Current.Impersonate())
						{
							this.CreateFileIfNecessary();

							return this.FileSystem.File.ReadAllText(this.Path);
						}
					});

				return this.ContentInternal.Value;
			}
		}

		protected internal virtual Lazy<string> ContentInternal { get; set; }
		protected internal virtual IEnvironment Environment { get; }
		protected internal virtual IFileSystem FileSystem { get; }

		public virtual string Path
		{
			get
			{
				// ReSharper disable InvertIf
				if(this._path == null)
				{
					var path = this.ConfigurationManager.ConnectionStrings.FirstOrDefault(item => item.Name.Equals("File"))?.ConnectionString;

					if(path == null)
						return null;

					const string dataDirectory = "|DataDirectory|";

					if(path.StartsWith(dataDirectory, StringComparison.OrdinalIgnoreCase))
					{
						var dataDirectoryPath = (this.ApplicationDomain.GetData("DataDirectory") as string ?? string.Empty).TrimEnd(@"\".ToCharArray());
						path = dataDirectoryPath + @"\" + path.Substring(dataDirectory.Length).TrimStart(@"\".ToCharArray());
					}

					this._path = new Lazy<string>(() => path);
				}
				// ReSharper restore InvertIf

				return this._path.Value;
			}
		}

		protected internal virtual IPrincipalContext PrincipalContext { get; }

		#endregion

		#region Methods

		public virtual void AddContent(string content)
		{
			if(string.IsNullOrEmpty(content))
				return;

			using(this.PrincipalContext.Current.Impersonate())
			{
				this.CreateFileIfNecessary();

				this.FileSystem.File.AppendAllText(this.Path, (!string.IsNullOrEmpty(this.Content) ? this.Environment.NewLine : string.Empty) + content);
			}

			this.ContentInternal = null;
		}

		public virtual void Clear()
		{
			using(this.PrincipalContext.Current.Impersonate())
			{
				this.CreateFileIfNecessary();

				this.FileSystem.File.WriteAllText(this.Path, string.Empty);
			}

			this.ContentInternal = null;
		}

		protected internal virtual void CreateFileIfNecessary()
		{
			try
			{
				var file = this.FileSystem.FileInfo.FromFileName(this.Path);

				if(file.Exists)
					return;

				if(!file.Directory.Exists)
					file.Directory.Create();

				this.FileSystem.File.WriteAllText(this.Path, string.Empty);
			}
			catch(Exception exception)
			{
				var windowsIdentity = WindowsIdentity.GetCurrent();

				// ReSharper disable PossibleNullReferenceException
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Could not create file if necessary for path \"{0}\". Current windows-identity: \"{1}\" (authentication-type: {2}, impersonation-level: {3}).", this.Path, windowsIdentity.Name, windowsIdentity.AuthenticationType, windowsIdentity.ImpersonationLevel), exception);
				// ReSharper restore PossibleNullReferenceException
			}
		}

		public virtual void TryRead()
		{
			using(this.PrincipalContext.Current.Impersonate())
			{
				this.CreateFileIfNecessary();

				this.FileSystem.File.ReadAllText(this.Path);
			}
		}

		#endregion
	}
}
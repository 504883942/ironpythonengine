using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;
using System.Security;
using System.Security.Policy;
using System.Security.Permissions;

namespace ironpythonengine
{
    public abstract class IronPythonEngine
    {
        protected ScriptEngine engine;
        protected ScriptScope scope;

        public ScriptScope get_scope() { return this.scope; }
        public ScriptEngine get_engine() { return this.engine; }
    }

    public class SecureIronPythonEngine : IronPythonEngine
    {
        protected readonly AppDomain domain;

        public SecureIronPythonEngine(string[] dir_paths=null) : base() {
            PermissionSet pset = new PermissionSet(PermissionState.None);
            pset.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            pset.AddPermission(new ReflectionPermission(PermissionState.Unrestricted));

            if (dir_paths != null) {
                pset.AddPermission(new FileIOPermission(FileIOPermissionAccess.Read | FileIOPermissionAccess.PathDiscovery, dir_paths));
            }

            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationBase = System.Environment.CurrentDirectory;
            this.domain = AppDomain.CreateDomain("IPyEngine", new Evidence(), setup, pset);

            this.engine = Python.CreateRuntime(domain).GetEngine("py");
            this.scope = this.engine.CreateScope();
        }
    
    }

    public class UnrestrictedIronPythonEngine : IronPythonEngine
    {

        public UnrestrictedIronPythonEngine(){
            this.engine = Python.CreateEngine();
            this.scope = this.engine.CreateScope();
        }
    }

}

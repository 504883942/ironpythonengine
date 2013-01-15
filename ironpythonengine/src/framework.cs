using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ironpythonengine
{
    public class Framework
    {
        public Framework(IronPythonEngine engine) { }


        public void run(CodeBundle code_bundle) { }
        public void run(string script) { }
        public void run_file(string file_path) { }
    }
}

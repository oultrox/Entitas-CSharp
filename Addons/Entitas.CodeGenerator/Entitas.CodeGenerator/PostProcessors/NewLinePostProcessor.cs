using System;

namespace Entitas.CodeGenerator {

    public class NewLinePostProcessor : ICodeGenFilePostProcessor {

        public string name { get { return "Convert newlines"; } }
        public int priority { get { return 90; } }
        public bool isEnabledByDefault { get { return true; } }
        public bool runInDryMode { get { return true; } }

        public CodeGenFile[] PostProcess(CodeGenFile[] files) {
            foreach(var file in files) {
                file.fileContent = file.fileContent.Replace("\n", Environment.NewLine);
            }

            return files;
        }
    }
}

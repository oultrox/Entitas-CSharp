using Entitas.CodeGenerator.Attributes;

namespace My.Namespace {

    [Context("Test"), Context("Test2")]
    public sealed class ClassToGenerate {
        public string value;
    }
}

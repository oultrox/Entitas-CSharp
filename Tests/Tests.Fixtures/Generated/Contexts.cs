//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ContextsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts : Entitas.IContexts {

    public static Contexts sharedInstance {
        get {
            if(_sharedInstance == null) {
                _sharedInstance = new Contexts();
            }

            return _sharedInstance;
        }
        set { _sharedInstance = value; }
    }

    static Contexts _sharedInstance;

    public GameContext game { get; set; }
    public TestContext test { get; set; }
    public Test2Context test2 { get; set; }

    public Entitas.IContext[] allContexts { get { return new Entitas.IContext [] { game, test, test2 }; } }

    public Contexts() {
        game = new GameContext();
        test = new TestContext();
        test2 = new Test2Context();

        var postConstructors = System.Linq.Enumerable.Where(
            GetType().GetMethods(),
            method => System.Attribute.IsDefined(method, typeof(Entitas.CodeGenerator.Attributes.PostConstructorAttribute))
        );

        foreach(var postConstructor in postConstructors) {
            postConstructor.Invoke(this, null);
        }
    }

    public void Reset() {
        var contexts = allContexts;
        for (int i = 0; i < contexts.Length; i++) {
            contexts[i].Reset();
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.EntityIndexGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class Contexts {

    public const string MyNamespaceEntityIndex = "MyNamespaceEntityIndex";
    public const string PrimaryEntityIndex = "PrimaryEntityIndex";
    public const string MyNamespaceCustomEntityIndex = "MyNamespaceCustomEntityIndex";

    [Entitas.CodeGenerator.Attributes.PostConstructor]
    public void InitializeEntityIndices() {
        test.AddEntityIndex(new Entitas.EntityIndex<TestEntity, string>(
            MyNamespaceEntityIndex,
            test.GetGroup(TestMatcher.MyNamespaceEntityIndex),
            (e, c) => ((My.Namespace.EntityIndexComponent)c).value));
        test2.AddEntityIndex(new Entitas.EntityIndex<Test2Entity, string>(
            MyNamespaceEntityIndex,
            test2.GetGroup(Test2Matcher.MyNamespaceEntityIndex),
            (e, c) => ((My.Namespace.EntityIndexComponent)c).value));

        game.AddEntityIndex(new Entitas.PrimaryEntityIndex<GameEntity, string>(
            PrimaryEntityIndex,
            game.GetGroup(GameMatcher.PrimaryEntityIndex),
            (e, c) => ((PrimaryEntityIndexComponent)c).value));

        test.AddEntityIndex(new MyNamespace.CustomEntityIndex(test));
    }
}

public static class ContextsExtensions {

    public static System.Collections.Generic.HashSet<TestEntity> GetEntitiesWithMyNamespaceEntityIndex(this TestContext context, string value) {
        return ((Entitas.EntityIndex<TestEntity, string>)context.GetEntityIndex(Contexts.MyNamespaceEntityIndex)).GetEntities(value);
    }

    public static System.Collections.Generic.HashSet<Test2Entity> GetEntitiesWithMyNamespaceEntityIndex(this Test2Context context, string value) {
        return ((Entitas.EntityIndex<Test2Entity, string>)context.GetEntityIndex(Contexts.MyNamespaceEntityIndex)).GetEntities(value);
    }

    public static GameEntity GetEntityWithPrimaryEntityIndex(this GameContext context, string value) {
        return ((Entitas.PrimaryEntityIndex<GameEntity, string>)context.GetEntityIndex(Contexts.PrimaryEntityIndex)).GetEntity(value);
    }

    public static System.Collections.Generic.HashSet<TestEntity> GetEntitiesWithPosition(this TestContext context, IntVector2 position) {
        return ((MyNamespace.CustomEntityIndex)(context.GetEntityIndex(Contexts.MyNamespaceCustomEntityIndex))).GetEntitiesWithPosition(position);
    }

    public static System.Collections.Generic.HashSet<TestEntity> GetEntitiesWithPosition2(this TestContext context, IntVector2 position, IntVector2 size) {
        return ((MyNamespace.CustomEntityIndex)(context.GetEntityIndex(Contexts.MyNamespaceCustomEntityIndex))).GetEntitiesWithPosition2(position, size);
    }

}
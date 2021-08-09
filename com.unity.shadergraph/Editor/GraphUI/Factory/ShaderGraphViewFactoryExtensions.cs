using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEditor.GraphToolsFoundation.Overdrive.BasicModel;
using UnityEditor.ShaderGraph.GraphUI.DataModel;
using UnityEditor.ShaderGraph.GraphUI.GraphElements;
using UnityEditor.ShaderGraph.GraphUI.GraphElements.Views;

namespace UnityEditor.ShaderGraph.GraphUI.Factory
{
    [GraphElementsExtensionMethodsCache(typeof(ShaderGraphView))]
    public static class ShaderGraphViewFactoryExtensions
    {
        public static IModelUI CreateGraphDataNode(this ElementBuilder elementBuilder, CommandDispatcher store,
            GraphDataNodeModel model)
        {
            var ui = new GraphDataNode();
            ui.SetupBuildAndUpdate(model, store, elementBuilder.View, elementBuilder.Context);
            return ui;
        }

        public static IModelUI CreateRedirectNode(this ElementBuilder elementBuilder, CommandDispatcher store,
            RedirectNodeModel model)
        {
            var ui = new RedirectNode();
            ui.SetupBuildAndUpdate(model, store, elementBuilder.View, elementBuilder.Context);
            return ui;
        }

        public static IModelUI CreateEdge(this ElementBuilder elementBuilder, CommandDispatcher store,
            EdgeModel model)
        {
            var ui = new RedirectableEdge();
            ui.SetupBuildAndUpdate(model, store, elementBuilder.View, elementBuilder.Context);
            return ui;
        }
    }
}

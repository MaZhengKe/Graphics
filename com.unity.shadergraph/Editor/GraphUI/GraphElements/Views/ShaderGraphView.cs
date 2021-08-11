﻿using System.Collections.Generic;
using System.Linq;
using UnityEditor.GraphToolsFoundation.Overdrive;
using UnityEditor.ShaderGraph.GraphUI.DataModel;
using UnityEditor.ShaderGraph.GraphUI.Utilities;
using UnityEngine.UIElements;

namespace UnityEditor.ShaderGraph.GraphUI.GraphElements.Views
{
    public class ShaderGraphView : GraphView
    {
        public ShaderGraphView(GraphViewEditorWindow window, CommandDispatcher commandDispatcher,
            string graphViewName)
            : base(window, commandDispatcher, graphViewName)
        {

        }

        protected override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            base.BuildContextualMenu(evt);
            evt.menu.AppendSeparator();
        }

        protected override void CollectCopyableGraphElements(IEnumerable<IGraphElementModel> elements, HashSet<IGraphElementModel> elementsToCopySet)
        {
            var elementsList = elements.ToList();

            base.CollectCopyableGraphElements(elementsList, elementsToCopySet);

            // Pasting a redirect should also paste an edge to its source node.
            foreach (var redirect in elementsList.OfType<RedirectNodeModel>())
            {
                var incomingEdge = redirect.GetIncomingEdges().FirstOrDefault();
                if (incomingEdge != null) elementsToCopySet.Add(incomingEdge);
            }
        }
    }
}

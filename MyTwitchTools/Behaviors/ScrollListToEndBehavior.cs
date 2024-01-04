using Microsoft.Xaml.Behaviors;
using MyTwitchTools.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyTwitchTools.Behaviors
{
    public class ScrollListToEndBehavior : Behavior<ListView>
    {
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source",
            typeof(IEnumerable),
            typeof(ScrollListToEndBehavior),
            new PropertyMetadata(null, OnSourceChanged));

        public IEnumerable Source
        {
            get { return (IEnumerable)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = (ScrollListToEndBehavior)d;
            if (e.OldValue is INotifyCollectionChanged oldCollection)
            {
                oldCollection.CollectionChanged -= behavior.OnCollectionChanged;
            }

            if (e.NewValue is INotifyCollectionChanged newCollection)
            {
                newCollection.CollectionChanged += behavior.OnCollectionChanged;
            }
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var lastItem = ((IEnumerable)sender).Cast<object>().LastOrDefault();
                if (lastItem != null)
                {
                    AssociatedObject.ScrollIntoView(lastItem);
                }
            }
        }

        protected override void OnDetaching()
        {
            if (Source is INotifyCollectionChanged collection)
            {
                collection.CollectionChanged -= OnCollectionChanged;
            }

            base.OnDetaching();
        }
    }
}

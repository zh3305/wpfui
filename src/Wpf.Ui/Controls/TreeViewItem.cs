// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.Specialized;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Wpf.Ui.Controls.IconElements;

namespace Wpf.Ui.Controls;

/// <summary>
/// Extended <see cref="System.Windows.Controls.TreeViewItem"/> with <see cref="Wpf.Ui.Common.SymbolRegular"/> properties.
/// </summary>
public class TreeViewItem : System.Windows.Controls.TreeViewItem
{
    /// <summary>
    /// Property for <see cref="Icon"/>.
    /// </summary>
    public static readonly DependencyProperty IconProperty = DependencyProperty.Register(nameof(Icon),
        typeof(IconElement), typeof(TreeViewItem),
        new PropertyMetadata(null));

    /// <summary>
    /// Gets or sets displayed <see cref="IconElement"/>.
    /// </summary>
    [Bindable(true), Category("Appearance")]
    public IconElement? Icon
    {
        get => (IconElement)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }


    internal ItemsControl ParentItemsControl => ItemsControl.ItemsControlFromItemContainer((DependencyObject)this);

    internal TreeView ParentTreeView
    {
        get
        {
            for (ItemsControl container = this.ParentItemsControl; container != null; container = ItemsControl.ItemsControlFromItemContainer((DependencyObject)container))
            {
                if (container is TreeView parentTreeView)
                    return parentTreeView;
            }
            return (TreeView)null;
        }
    }

    internal TreeViewItem ParentTreeViewItem => ParentItemsControl as TreeViewItem;

    protected override DependencyObject GetContainerForItemOverride() => (DependencyObject)new TreeViewItem();

    protected override bool IsItemItsOwnContainerOverride(object item) => item is TreeViewItem;
}

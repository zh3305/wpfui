// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using Wpf.Ui.Controls.IconElements;

namespace Wpf.Ui.Controls;

/// <summary>
/// Extended <see cref="System.Windows.Controls.TreeViewItem"/> with <see cref="Wpf.Ui.Common.SymbolRegular"/> properties.
/// </summary>
public class TreeView : System.Windows.Controls.TreeView
{
    public TreeView()
    {
    }

    protected override DependencyObject GetContainerForItemOverride() => (DependencyObject)new Wpf.Ui.Controls.TreeViewItem();

    protected override bool IsItemItsOwnContainerOverride(object item) => item is Wpf.Ui.Controls.TreeViewItem;
}

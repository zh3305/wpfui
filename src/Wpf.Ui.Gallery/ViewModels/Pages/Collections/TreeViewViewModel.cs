// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.ObjectModel;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Wpf.Ui.Gallery.ViewModels.Pages.Collections;

public partial class TreeViewViewModel : ObservableObject
{
    public TreeViewViewModel()
    {
        TreeInfo = new List<TreeNodeModel>()
        {
            new TreeNodeModel(){
                NodeID = "1", NodeName = "苹果",Children=new List<TreeNodeModel>(){
                    new TreeNodeModel(){ NodeID="1.1", NodeName ="苹果A" },
                    new TreeNodeModel(){ NodeID="1.2", NodeName ="苹果B" },
                    new TreeNodeModel(){ NodeID="1.3", NodeName ="苹果C",Children = new List<TreeNodeModel>(){
                        new TreeNodeModel(){ NodeID="1.3.1", NodeName ="苹果C1" },
                        new TreeNodeModel(){ NodeID="1.3.2", NodeName ="苹果C2" },
                    } },

                }
            },
            new TreeNodeModel(){
                NodeID = "2", NodeName = "香蕉",Children=new List<TreeNodeModel>(){
                    new TreeNodeModel(){ NodeID="2.1", NodeName ="香蕉A" },
                    new TreeNodeModel(){ NodeID="2.2", NodeName ="香蕉B" },
                    new TreeNodeModel(){ NodeID="2.3", NodeName ="香蕉C" }
                }
            }
        };
    }
    [ObservableProperty]
    private List<TreeNodeModel> _treeInfo;

    private int _listViewSelectionModeComboBoxSelectedIndex = 0;

    public int ListViewSelectionModeComboBoxSelectedIndex
    {
        get => _listViewSelectionModeComboBoxSelectedIndex;
        set
        {
            SetProperty<int>(ref _listViewSelectionModeComboBoxSelectedIndex, value);
            UpdateListViewSelectionMode(value);
        }
    }

    [ObservableProperty]
    private SelectionMode? _listViewSelectionMode =null;

    private void UpdateListViewSelectionMode(int selectionModeIndex)
    {
        ListViewSelectionMode = selectionModeIndex switch
        {
            1 => SelectionMode.Single,
            2 => SelectionMode.Multiple,
            _ => null
        };
    }
}
public class TreeNodeModel : ObservableObject
{
    public string NodeID { get; set; }
    public string NodeName { get; set; }
    public List<TreeNodeModel> Children { get; set; }
}

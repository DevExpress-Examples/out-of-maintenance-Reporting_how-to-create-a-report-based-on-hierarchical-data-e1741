using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.Reflection;

namespace RepTreeListHierarchicalDataRelationships {

    public class DataSetHelper {

        static private Type itemType;

        static public DataSet HierarchicalListToDataSet<T>(List<T> hlist, string keyFieldName, string parentFieldName) {
            DataSetHelper.itemType = typeof(T);
            DataSet dataSet = new DataSet();
            List<int> currentLevelIds = new List<int>(new int[] { 0 });
            List<int> nextLevelIds = new List<int>();
            int count = 0;

            do {
                DataTable dataTable = GetNewTable(DataSetHelper.itemType.Name + (count == 0 ? "RootTable" : "Table" + count.ToString()), keyFieldName);

                for(int i = 0; i < hlist.Count; i++) {
                    for(int j = 0; j < currentLevelIds.Count; j++) {

                        if(Convert.ToInt32(DataSetHelper.itemType.GetProperty(parentFieldName).GetValue(hlist[i], null)) == currentLevelIds[j]) {
                            AddItemToTable(dataTable, hlist[i]);
                            nextLevelIds.Add(Convert.ToInt32(DataSetHelper.itemType.GetProperty(keyFieldName).GetValue(hlist[i], null)));
                        }

                    }
                }

                if(nextLevelIds.Count > 0) {
                    dataSet.Tables.Add(dataTable);
                    if(count > 0) // Not a root table
                        dataSet.Relations.Add(string.Format("{0}Level{1}Relation", DataSetHelper.itemType.Name, count), dataSet.Tables[count - 1].Columns[keyFieldName], dataTable.Columns[parentFieldName]);
                }

                currentLevelIds.Clear();
                currentLevelIds.AddRange(nextLevelIds);
                nextLevelIds.Clear();
                count++;

            } while(currentLevelIds.Count > 0);

            return dataSet;
        }

        static private DataTable GetNewTable(string tableName, string keyFieldName) {
            DataTable dt = new DataTable(tableName);
            PropertyInfo[] properties = DataSetHelper.itemType.GetProperties();

            foreach(PropertyInfo property in properties) {
                dt.Columns.Add(property.Name, property.PropertyType);
            }

            dt.Constraints.Add("IDPK", dt.Columns[keyFieldName], true);

            return dt;
        }

        static private void AddItemToTable(DataTable dataTable, object item) {
            DataRow dataRow = dataTable.NewRow();
            PropertyInfo[] properties = DataSetHelper.itemType.GetProperties();

            foreach(PropertyInfo property in properties) {
                dataRow[property.Name] = property.GetValue(item, null);
            }

            dataTable.Rows.Add(dataRow);
        }

    }


    public class DataSetHelper2 {

        static public void FillTreeView(TreeView treeView, DataSet dataSet) {
            treeView.BeginUpdate();
            treeView.Nodes.Clear();

            for(int i = 0; i < dataSet.Tables.Count; i++) {
                treeView.Nodes.Add(dataSet.Tables[i].TableName);
                AddColumnsAndRelations(treeView.Nodes[i], dataSet.Tables[i]);
            }

            treeView.ExpandAll();
            treeView.EndUpdate();
        }

        static private void AddColumnsAndRelations(TreeNode dataTableTreeNode, DataTable dataTable) {
            DataSet dataSet = dataTable.DataSet;

            for(int i = 0; i < dataTable.Columns.Count; i++) {
                dataTableTreeNode.Nodes.Add(dataTable.Columns[i].ColumnName);
            }

            for(int i = 0; i < dataSet.Relations.Count; i++) {
                if(dataSet.Relations[i].ParentTable == dataTable) {
                    TreeNode relationNode = dataTableTreeNode.Nodes.Add(dataSet.Relations[i].RelationName);

                    AddColumnsAndRelations(relationNode, dataSet.Relations[i].ChildTable);
                }
            }
        }
        
    }

}

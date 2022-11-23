<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128599596/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E1741)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [HierarchicalData.cs](./CS/HierarchicalData.cs) (VB: [HierarchicalData.vb](./VB/HierarchicalData.vb))
* [HierarchyToDataSet.cs](./CS/HierarchyToDataSet.cs) (VB: [HierarchyToDataSet.vb](./VB/HierarchyToDataSet.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
* [XtraReport1.cs](./CS/XtraReport1.cs) (VB: [XtraReport1.vb](./VB/XtraReport1.vb))
<!-- default file list end -->
# How to create a report based on hierarchical data


<p>Generally, there is no standard method to use hierarchical data, i. e. the data that is organized into a tree-like structure (see the <a href="http://en.wikipedia.org/wiki/Hierarchical_model">Hierarchical model</a>) as a datasource for the XtraReport. However, you can manually implement an effective and generic algorithm that performs data transformation from the hierarchical structure to the relational one.</p><p>This example demonstrates how it can be done. The core of this example is the RepTreeListHierarchicalDataRelationships.DataSetHelper.HierarchicalListToDataSet<T>() generic method, which transforms a List<T> to the DataSet. Also, please take special note of the fact that the RepTreeListHierarchicalDataRelationships.Form1.GenerateReport() method, which dynamically generates a report, based on the resulting DataSet.</p>

<br/>



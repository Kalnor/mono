//
// ProjectInstanceTest.cs
//
// Author:
//   Atsushi Enomoto (atsushi@xamarin.com)
//
// Copyright (C) 2013 Xamarin Inc. (http://www.xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using System;
using System.IO;
using System.Linq;
using System.Xml;
using Microsoft.Build.Construction;
using Microsoft.Build.Execution;
using NUnit.Framework;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;
using Microsoft.Build.Logging;

namespace MonoTests.Microsoft.Build.Execution
{
	[TestFixture]
	public class ProjectInstanceTest
	{
		[Test]
		public void ItemsAndProperties ()
		{
            string project_xml = @"<Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <ItemGroup>
    <X Condition='false' Include='bar.txt' />
    <X Include='foo.txt'>
      <M>m</M>
      <N>=</N>
    </X>
  </ItemGroup>
  <PropertyGroup>
    <P Condition='false'>void</P>
    <P Condition='true'>valid</P>
  </PropertyGroup>
</Project>";
            var xml = XmlReader.Create (new StringReader(project_xml));
            var root = ProjectRootElement.Create (xml);
            var proj = new ProjectInstance (root);
            var item = proj.Items.First ();
			Assert.AreEqual ("foo.txt", item.EvaluatedInclude, "#1");
			var prop = proj.Properties.First (p => p.Name=="P");
			Assert.AreEqual ("valid", prop.EvaluatedValue, "#2");
			Assert.IsNotNull (proj.GetProperty ("MSBuildProjectDirectory"), "#3");
			Assert.AreEqual ("2.0", proj.ToolsVersion, "#4");
		}
		
		[Test]
		public void ExplicitToolsVersion ()
		{
            string project_xml = @"<Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003' />";
            var xml = XmlReader.Create (new StringReader(project_xml));
            var root = ProjectRootElement.Create (xml);
			var proj = new ProjectInstance (root, null, "4.0", new ProjectCollection ());
			Assert.AreEqual ("4.0", proj.ToolsVersion, "#1");
		}
		
		[Test]
		public void BuildEmptyProject ()
		{
			string project_xml = @"<Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003' />";
			var xml = XmlReader.Create (new StringReader (project_xml), null, "file://localhost/foo.xml");
			var root = ProjectRootElement.Create (xml);
			// This seems to do nothing and still returns true
			root.FullPath = "ProjectInstanceTest.BuildEmptyProject.1.proj";
			Assert.IsTrue (new ProjectInstance (root).Build (), "#1");
			// This seems to fail to find the appropriate target
			root.FullPath = "ProjectInstanceTest.BuildEmptyProject.2.proj";
			Assert.IsFalse (new ProjectInstance (root).Build ("Build", null), "#2");
			// Thus, this tries to build all the targets (empty) and no one failed, so returns true(!)
			root.FullPath = "ProjectInstanceTest.BuildEmptyProject.3.proj";
			Assert.IsTrue (new ProjectInstance (root).Build (new string [0], null), "#3");
			// Actially null "targets" is accepted and returns true(!!)
			root.FullPath = "ProjectInstanceTest.BuildEmptyProject.4.proj";
			Assert.IsTrue (new ProjectInstance (root).Build ((string []) null, null), "#4");
			// matching seems to be blindly done, null string also results in true(!!)
			root.FullPath = "ProjectInstanceTest.BuildEmptyProject.5.proj";
			Assert.IsTrue (new ProjectInstance (root).Build ((string) null, null), "#5");
		}
		
		[Test]
		public void DefaultTargets ()
		{
			string project_xml = @"<Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <Import Project='$(MSBuildToolsPath)\Microsoft.Common.targets' />
</Project>";
			var xml = XmlReader.Create (new StringReader(project_xml));
			var root = ProjectRootElement.Create (xml);
			var proj = new ProjectInstance (root);
			Assert.AreEqual (1, proj.DefaultTargets.Count, "#1");
			Assert.AreEqual ("Build", proj.DefaultTargets [0], "#2");
		}
		
		[Test]
		public void DefaultTargets2 ()
		{
            string project_xml = @"<Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <Import Project='$(MSBuildToolsPath)\Microsoft.CSharp.targets' />
</Project>";
            var xml = XmlReader.Create (new StringReader (project_xml));
            var root = ProjectRootElement.Create (xml);
			root.FullPath = "ProjectTest.BuildCSharpTargetBuild.proj";
			var proj = new ProjectInstance (root);
			Assert.AreEqual (1, proj.DefaultTargets.Count, "#1");
			Assert.AreEqual ("Build", proj.DefaultTargets [0], "#2");
		}
		
		[Test]
		public void PropertyOverrides ()
		{
            string project_xml = @"<Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <PropertyGroup>
    <X>x</X>
  </PropertyGroup>
  <PropertyGroup>
    <X>y</X>
  </PropertyGroup>
</Project>";
            var xml = XmlReader.Create (new StringReader (project_xml));
            var root = ProjectRootElement.Create (xml);
			root.FullPath = "ProjectTest.BuildCSharpTargetBuild.proj";
			var proj = new ProjectInstance (root);
			Assert.AreEqual ("y", proj.GetPropertyValue ("X"), "#1");
		}
		
		[Test]
		public void FirstUsingTaskTakesPrecedence1 ()
		{
			FirstUsingTaskTakesPrecedenceCommon (false, false);
		}
		
		[Test]
		public void FirstUsingTaskTakesPrecedence2 ()
		{
			FirstUsingTaskTakesPrecedenceCommon (true, true);
		}
		
		public void FirstUsingTaskTakesPrecedenceCommon (bool importFirst, bool buildShouldSucceed)
		{
			string thisAssembly = new Uri (GetType ().Assembly.CodeBase).LocalPath;
			string filename = "Test/ProjectTargetInstanceTest.FirstUsingTaskTakesPrecedence.Import.proj";
			string imported_xml = string.Format (@"<Project DefaultTargets='Foo' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <UsingTask TaskName='MonoTests.Microsoft.Build.Execution.MyTask' AssemblyFile='{0}' />
</Project>", thisAssembly);
			string usingTask =  string.Format ("<UsingTask TaskName='MonoTests.Microsoft.Build.Execution.SubNamespace.MyTask' AssemblyFile='{0}' />", thisAssembly);
			string import = string.Format ("<Import Project='{0}' />", filename);
			string project_xml = string.Format (@"<Project DefaultTargets='Foo' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
			{0}
			{1}
  <Target Name='Foo'>
    <MyTask />
  </Target>
</Project>", 
				importFirst ? import : usingTask, importFirst ? usingTask : import);
			try {
				File.WriteAllText (filename, imported_xml);
				var xml = XmlReader.Create (new StringReader (project_xml));
				var root = ProjectRootElement.Create (xml);
				Assert.IsTrue (root.UsingTasks.All (u => !string.IsNullOrEmpty (u.AssemblyFile)), "#1");
				Assert.IsTrue (root.UsingTasks.All (u => string.IsNullOrEmpty (u.AssemblyName)), "#2");
				root.FullPath = "ProjectTargetInstanceTest.FirstUsingTaskTakesPrecedence.proj";
				var proj = new ProjectInstance (root);
				Assert.AreEqual (buildShouldSucceed, proj.Build (), "#3");
			} finally {
				File.Delete (filename);
			}
		}
		
		[Test]
		public void MissingTypeForUsingTaskStillWorks ()
		{
			string thisAssembly = new Uri (GetType ().Assembly.CodeBase).LocalPath;
			string project_xml = string.Format (@"<Project DefaultTargets='X' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <UsingTask AssemblyFile='{0}' TaskName='NonExistent' />
  <Target Name='X' />
</Project>", thisAssembly);
            var xml = XmlReader.Create (new StringReader (project_xml));
            var root = ProjectRootElement.Create (xml);
			root.FullPath = "ProjectInstanceTest.MissingTypeForUsingTaskStillWorks.proj";
			var proj = new ProjectInstance (root);
			Assert.IsTrue (proj.Build (), "#1");
		}
		
		[Test]
		public void MissingTypeForUsingTaskStillWorks2 ()
		{
			string thisAssembly = new Uri (GetType ().Assembly.CodeBase).LocalPath;
			string project_xml = @"<Project DefaultTargets='X' xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
  <UsingTask AssemblyFile='nonexistent.dll' TaskName='NonExistent' />
  <Target Name='X' />
</Project>";
            var xml = XmlReader.Create (new StringReader (project_xml));
            var root = ProjectRootElement.Create (xml);
			root.FullPath = "ProjectInstanceTest.MissingTypeForUsingTaskStillWorks2.proj";
			var proj = new ProjectInstance (root);
			Assert.IsTrue (proj.Build (), "#1");
		}
	}
	
	namespace SubNamespace
	{
		public class MyTask : Task
		{
			public override bool Execute ()
			{
				return false;
			}
		}
	}
		
	public class MyTask : Task
	{
		public override bool Execute ()
		{
			return true;
		}
	}
}


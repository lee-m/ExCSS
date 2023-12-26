using System;
using System.Linq;

using ExCSS.New.Values;

using Xunit;

namespace ExCSS.Tests
{
	public class RealWorld
	{
		[Fact]
		public void ParseCss_WithStandardString_ExpectReadableProperties()
		{
			// Could read in a file here...
			// Arrange
			string css = "html{ background-color: #5a5eed; color: #FFFFFF; margin: 5px; } h2{ background-color: red }";
			
			// Act
			var stylesheet = new StylesheetParser().Parse(css);

			// Get the info out - New way
			var info = stylesheet.StyleRules.First() as StyleRule;
			var selector = info.SelectorText;
			var backgroundColor = info.Style.BackgroundColor;
			var foregroundColor = info.Style.Color;
			var margin = info.Style.Margin;

			// Assert
			Assert.Equal("html", selector);
			Assert.Equal("rgb(90, 94, 237)", backgroundColor.Value.As<ColorValue>().ToString());
			Assert.Equal("rgb(255, 255, 255)", foregroundColor);
			Assert.Equal("5px", margin);
		}

		[Fact(Skip = "TODO: setter")]
		public void CreateStylesheet_WithCssProperties_ExpectStandardStringBack()
		{
			// Arrange
			string expectedResult = @"h1 { background-color: rgb(255, 0, 0) }" + Environment.NewLine 
									+ "h2 { background-color: rgb(0, 128, 0) }";

			var newParser = new StylesheetParser();

			StyleRule r = new StyleRule(newParser);
			r.SelectorText = "h1";
			//TODO
			//r.Style.BackgroundColor = "red";

			StyleRule r2 = new StyleRule(newParser);
			r2.SelectorText = "h2";
			//TODO
			//r2.Style.BackgroundColor = "green";

			// Act
			var newstylesheet = r.ToCss() + Environment.NewLine + r2.ToCss();

			// Assert
			Assert.Equal(expectedResult, newstylesheet);
		}
	}
}

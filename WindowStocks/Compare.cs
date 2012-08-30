// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Compare.cs" company="NSnaiL">
//   Copyright (C) 2009 NSnaiL
// </copyright>
// <summary>
//   Defines the Compare type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WindowStocks
{
	using System.Drawing;

	public static class Compare
	{
		public static bool FontCompare(Font a, Font b)
		{
			return a.Bold == b.Bold
				//&& a.FontFamily == b.FontFamily
				//&& a.GdiCharSet == b.GdiCharSet
				&& a.GdiVerticalFont == b.GdiVerticalFont
				&& a.Height == b.Height
				&& a.IsSystemFont == b.IsSystemFont
				&& a.Italic == b.Italic
				&& a.Name == b.Name
				//&& a.OriginalFontName == b.OriginalFontName
				&& a.Size == b.Size
				&& a.SizeInPoints == b.SizeInPoints
				&& a.Strikeout == b.Strikeout
				&& a.Style == b.Style
				&& a.SystemFontName == b.SystemFontName
				&& a.Underline == b.Underline
				&& a.Unit == b.Unit;
		}

	}
}

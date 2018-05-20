﻿using System;
using System.IO;
using System.Windows;
using ClEngine.CoreLibrary.Asset;
using ClEngine.CoreLibrary.Logger;
using ClEngine.Model;
using ClEngine.Tiled.MapEnum;
using Microsoft.Win32;

namespace ClEngine.View.Map
{
	/// <summary>
	/// CreateMapWindow.xaml 的交互逻辑
	/// </summary>
	public partial class CreateMapWindow : Window
	{
		private MapModel MapModel { get; set; }
		public CreateMapWindow()
		{
			InitializeComponent();

			MapModel = new MapModel();
			DataContext = MapModel;
		}

		private void CreateMap_OnClick(object sender, RoutedEventArgs e)
		{
			if (Equals(MapTabControl.SelectedItem, SelfTabItem))
			{
				Tiled.Map map = new Tiled.Map();
				int.TryParse(FixedX.Text, out var width);
				int.TryParse(FixedY.Text, out var height);
				int.TryParse(BlockWidth.Text, out var blockWidth);
				int.TryParse(BlockHeight.Text, out var blockHeight);
				Enum.TryParse(MapDirection.SelectedValue.ToString(), out MapOrientation orientation);
				Enum.TryParse(RenderOrder.SelectedValue.ToString(), out RenderOrder renderOrder);
				map.Width = width;
				map.Height = height;
				map.Tilewidth = blockWidth;
				map.Tileheight = blockHeight;
				map.Orientation = orientation;
				map.Renderorder = renderOrder;
                
				// TODO: Create Map
			}
			else if (Equals(MapTabControl.SelectedItem, MapTabItem))
			{
				var surfaceGridHeight = 0;
				var surfaceGridWidth = 0;
				var logicGridWidth = 0;
				var logicGridHeight = 0;
				if (!CheckMapTabItem(ref surfaceGridHeight, ref surfaceGridWidth, ref logicGridWidth, ref logicGridHeight))
					return;

				MapModel.SurfaceGridHeight = surfaceGridHeight;
				MapModel.SurfaceGridWidth = surfaceGridWidth;
				MapModel.LogicGridWidth = logicGridWidth;
				MapModel.LogicGridHeight = logicGridHeight;
				MapModel.Name = MapName.Text;
				MapModel.ImageName = Path.GetFileNameWithoutExtension(ImagePath.Text);
			}

			DialogResult = true;
		}

		private bool CheckMapTabItem(ref int logicGridHeight, ref int logicGridWidth, ref int surfaceGridHeight,
			ref int surfaceGridWidth)
		{
			if (string.IsNullOrEmpty(MapName.Text))
			{
                Logger.Error("地图名称不能为空");
				return false;
			}

			if (!int.TryParse(LogicGridHeight.Text, out logicGridHeight))
			{
			    Logger.Error("逻辑格子高度必须为数值");
                return false;
			}

			if (!int.TryParse(LogicGridWidth.Text, out logicGridWidth))
			{
			    Logger.Error("逻辑格子宽度必须为数值");

				return false;
			}

			if (!int.TryParse(SurfaceGridHeight.Text, out surfaceGridHeight))
			{
			    Logger.Error("地表格子高度必须为数值");

				return false;
			}

			if (!int.TryParse(SurfaceGridWidth.Text, out surfaceGridWidth))
			{
			    Logger.Error("地表格子宽度必须为数值");

				return false;
			}

			if (string.IsNullOrEmpty(ImagePath.Text))
			{
			    Logger.Error("必须选择图片作为地图");

				return false;
			}

			return true;
		}

		private void BrowserMap_OnClick(object sender, RoutedEventArgs e)
		{
			var loadMap = new OpenFileDialog
			{
				CheckFileExists = true,
				CheckPathExists = true,
				Multiselect = false,
				Filter = "地图文件(*.tmx, *.xml, *.json)|*.tmx;*.xml;*.json"
			};
			var dialogResult = loadMap.ShowDialog();
			if (dialogResult == true)
			{
				ImagePath.Text = loadMap.FileName;
			}
		}
	}
}

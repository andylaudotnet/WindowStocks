namespace WindowStocks.Sign
{
	using System;
	using System.Management;
	using System.Security.Cryptography;
	using System.Text;
	using System.Windows.Forms;
	using www.beta_1.cn;

	internal static class Program
	{
		#region Methods (3)

		// Private Methods (3) 

		private static string AESEncrypt(string toEncrypt)
		{
			byte[] keyArray = Encoding.UTF8.GetBytes("90B82F0F11AB4a7796C3B3D60F71AD7C");
			byte[] toEncryptArray = Encoding.UTF8.GetBytes(toEncrypt);

			RijndaelManaged rDel = new RijndaelManaged();
			rDel.Key = keyArray;
			rDel.Mode = CipherMode.ECB;
			rDel.Padding = PaddingMode.PKCS7;

			ICryptoTransform cTransform = rDel.CreateEncryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}

		/// <summary>
		/// 取得设备网卡的MAC地址
		/// </summary>
		private static string GetMacAddress()
		{
			ManagementObjectCollection moc = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
			foreach (ManagementObject mo in moc)
				if ((bool)mo["IPEnabled"])
					return mo["MacAddress"] as string;
			return null;
		}

		[STAThread]
		private static void Main(string[] args)
		{
			if (args.Length == 0) return;

			//取得网卡地址
			string mac = GetMacAddress();
			if (mac == null) return;
			mac = mac.Replace(":", string.Empty);

			try {
				windowstocks_services webService = new windowstocks_services();

				if (args[0] == "signin") {
					//窗口行情版本号.
					const string windowStocksVer = WindowStocks.Program.ProductVersion + " " + WindowStocks.Program.ProductVersionAdditional;
					string encryptStr = AESEncrypt(string.Format("{0}|{1}|{2}|{3}|{4},{5}", mac, windowStocksVer, Environment.OSVersion, Environment.Version, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
					webService.SignIn(encryptStr);
				} else if (args[0] == "signout") {
					string encryptStr = AESEncrypt(mac);
					webService.SignOut(encryptStr);
				}
			} catch {
			}
		}

		#endregion Methods
	}
}

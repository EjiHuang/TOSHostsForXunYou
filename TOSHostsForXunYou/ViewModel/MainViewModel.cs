using System;
using System.Linq;
using TOSHostsForXunYou.HostsEdit;
using TOSHostsForXunYou.Mvvm;

namespace TOSHostsForXunYou.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly string ip = "168.95.245.1";
        private readonly string domain = "tospatch.x2game.com.tw";

        public MainViewModel()
        {
            HostsHelper.InitHostsData();
            // 判断是否已经存在？
            if (HostsHelper.hostsDatas.Any(x => x.Domain == domain && x.State == "激活"))
            {
                StatusText = "检测到已经存在映射。";
                IsEnableText = "关闭Hosts映射";
            }
        }

        public string StatusText
        {
            get => _statusText;
            set => Set(ref _statusText, value);
        }
        private string _statusText = "未检测到Hosts映射。";

        public string IsEnableText
        {
            get => _isEnableText;
            set => Set(ref _isEnableText, value);
        }
        private string _isEnableText = "开启Hosts映射";

        public RelayCommand EnableHostsWrapCommand
        {
            get => new RelayCommand(() =>
              {
                  // 关闭
                  if (IsEnableText == "关闭Hosts映射")
                  {
                      var target = HostsHelper.hostsDatas.First(x => x.Domain == domain);
                      HostsHelper.UpdateHosts($"#{target.Ip} {target.Domain}");
                      IsEnableText = "开启Hosts映射";
                      StatusText = "关闭成功。";
                  }
                  // 开启
                  else if (IsEnableText == "开启Hosts映射")
                  {
                      HostsHelper.UpdateHosts($"{ip} {domain}");
                      IsEnableText = "关闭Hosts映射";
                      StatusText = "映射成功，进游戏后可关闭程序。";
                  }

                  // 刷新并输出当前Hosts列表
                  HostsHelper.InitHostsData();
                  foreach (var v in HostsHelper.hostsDatas)
                  {
                      Console.WriteLine($"{v.Ip}\t{v.Domain}\t{v.State}");
                  }
              });
        }

        public void HostsExit()
        {
            // 关闭
            if (IsEnableText == "关闭Hosts映射")
            {
                var target = HostsHelper.hostsDatas.First(x => x.Domain == domain);
                HostsHelper.UpdateHosts($"#{target.Ip} {target.Domain}");
            }
        }
    }
}

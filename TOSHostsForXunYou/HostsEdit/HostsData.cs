/*
 https://github.com/ercJuL/Wpf_github_hosts/blob/master/WPF_Best_Hosts
 */

using System.ComponentModel;

namespace TOSHostsForXunYou.HostsEdit
{
    public class HostsData : INotifyPropertyChanged
    {
        private string _ip;
        private string _domain;
        private string _state;

        public string Ip
        {
            get => _ip;
            set
            {
                _ip = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ip"));
            }
        }

        public string Domain
        {
            get => _domain;
            set
            {
                _domain = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Domain"));
            }
        }

        public string State
        {
            get => _state;
            set
            {
                _state = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("State"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

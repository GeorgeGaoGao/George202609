using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace _41.SmallProjectExercise
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Sentence> Poetries { get; set; } = new ObservableCollection<Sentence>();
        public MainWindowViewModel()
        {
            Poetries.Add(new Sentence() { Content = "红军不怕远征难，万水千山只等闲。" });
            Poetries.Add(new Sentence() { Content = "五岭逶迤腾细浪，乌蒙磅礴走泥丸。" });
            Poetries.Add(new Sentence() { Content = "金沙水拍云崖暖，大渡桥横铁索寒。" });
            Poetries.Add(new Sentence() { Content = "更喜岷山千里雪，三军过后尽开颜。" });
        }
    }
}

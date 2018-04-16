using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;//引入命名空间

namespace SayWord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SpeechSynthesizer synth = new SpeechSynthesizer();
        private void button1_Click(object sender, EventArgs e)
        {
            //从.NET Framework 3.0开始，Framework提供了Speech API调用方法，这样就非常流畅完美了，不用再纠结非托管的COM了。
            //首先、右键项目、添加引用
            //左边分类选择框架、右边找到System.Speech
            //然后在你的程序中添加using引用
            //using System.Speech.Synthesis;
            //最后调用SpeechSynthesizer对象的Speak方法朗读即可
           
           // synth.Speak("韩伟是谁啊，他喜欢谁啊？哈哈哈！！");

            //这里会出现一个比较烦人的问题，Speak方法时单线程的，也就是说，在它朗读的过程中，当前程序的其他操作会全部卡掉、
            //等其朗读完毕，就又可以继续操作了、

            //Async：异步的
            synth.Rate = 3;//语速-10~10
            if (this.textBox1.Text.Trim().Length ==0)
            {
                 synth.SpeakAsync("请输入内容");
            }
            else
            {
                synth.SpeakAsync(this.textBox1.Text);//开始朗读，传入指定的内容
            }
           // 然后就惊喜的发现、朗读的时候不卡了、呵呵、其他的还有设置声音(synth.Volumn)、语速(synth.Rate)等等、
            //大家可以百度SpeechSynthesizer的使用、很多例子。
        }
    }
}

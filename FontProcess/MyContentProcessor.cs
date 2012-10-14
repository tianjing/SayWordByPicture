using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline.Processors;

// TODO: 将这些项替换为处理器输入和输出类型。
using TInput = System.String;
using TOutput = System.String;
using System.IO;
using System.Text;
using System.ComponentModel;

namespace FontProcess
{
    /// <summary>
    /// 此类将由 XNA Framework 内容管道实例化，
    /// 以便将自定义处理应用于内容数据，将对象转换用于类型 TInput 到
    /// 类型 TOnput 的改变。如果处理器希望改变数据但不更改其类型，
    /// 输入和输出类型可以相同。
    ///
    /// 这应当属于内容管道扩展库项目的一部分。
    ///
    /// TODO: 更改 ContentProcessor 属性以为此处理器指定
    /// 正确的显示名称。
    /// </summary>
    [ContentProcessor(DisplayName = "FontProcess.MyContentProcessor")]//这个名字将用于SpriteFont的Content Processor属性
    public class MyContentProcessor : FontDescriptionProcessor
    {
        [DefaultValue("../SayWordByPictureContent/Chinese.txt")]
        [DisplayName("Message File")]
        [Description("The characters in this file will be automatically added to the font.")]
        public String FilePath { get { return m_FilePath; } set { m_FilePath = value; } }

        private string m_FilePath = String.Empty;//注意这里的路径，因为FontDescription.txt文件在XNAGameFontContent项目的Fonts文件夹中
        public override SpriteFontContent Process(FontDescription input, ContentProcessorContext context)
        {
            string path = Path.GetFullPath(m_FilePath);
            context.AddDependency(path);
            string content = File.ReadAllText(path, Encoding.UTF8);//FontDescription.txt文件必须保存成utf-8格式，此处也需使用utf-8读取
            foreach (char c in content)//读取文件中字符，存放到FontDescription中
            {
                input.Characters.Add(c);
            }
            return base.Process(input, context);
        }
    }
}

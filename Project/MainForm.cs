﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatternsFinal
{
    public partial class MainForm : Form
    {
        //private World gameWorld;
        private ConsoleToTextbox_Adaptor _writer;

        public MainForm()
        {
            InitializeComponent();
            //SplashForm Splash = new SplashForm();
            //Splash.Show();

            this.Show();
            //Splash.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            God hero1 = new Poseidon();
            God hero2 = new Poseidon();
            hero2.setName("Bob");
            God hero3 = new Poseidon();
            hero3.setName("Sam");
            God hero4 = new Poseidon();
            hero4.setName("Bilbo");
            God hero5 = new Poseidon();
            hero5.setName("Frodo");

            Party heroParty = new Party();
            Dictionary<String, God> hero_list = new Dictionary<String, God>();
            hero_list.Add(hero1.getName(), hero1);
            hero_list.Add(hero2.getName(), hero2);
            hero_list.Add(hero3.getName(), hero3);
            hero_list.Add(hero4.getName(), hero4);
            hero_list.Add(hero5.getName(), hero5);
            NewGameForm newGame = new NewGameForm(heroParty, hero_list);
            this.Hide();
            //gameWorld = new World();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                World gameWorld;
                Stream TestFileStream = File.OpenRead("SerialSave");
                BinaryFormatter deserializer = new BinaryFormatter();
                gameWorld = (World)deserializer.Deserialize(TestFileStream);
                TestFileStream.Close();
                gameWorld.init();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void stub_saveWorld()
        {
            Stream TestFileStream = File.Create("SerialSave");
            BinaryFormatter serializer = new BinaryFormatter();
            //serializer.Serialize(TestFileStream, gameWorld);
            TestFileStream.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _writer = new ConsoleToTextbox_Adaptor(textConsole);
            Console.SetOut(_writer);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

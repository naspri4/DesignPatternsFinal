﻿using System;
using System.Collections.Generic;

namespace DesignPatternsFinal
{
    public class Battle
    {
        private Party home;
        private Party away;
        private List<int> speed;// = new List<int>() ;
        private bool fighting;
           
        public Battle(ref Party home, ref Party away)
        {
            fighting = true;
            this.home = home;
            this.away = away;
            
            speed = new List<int>();

            foreach (Character person in home)
                speed.Add(person.Dex);
            foreach (Character person in away)
                speed.Add(person.Dex);
        }

        public void setHome(Party home)
        {
            this.home = home;
        }

        public void setAway(Party away)
        {
            this.away = away;
        }
        public String turn()
        {
            String response = "";
            for (int i = 0; i < home.size(); i++)
            {
                if (speed[i] != 0)
                    speed[i]--;
                else
                {
                    if (away.size() > 0)
                    {
                        IAbility action;
                        action = home.getCharacter(i).turn(home, away);
                        response += action.ability(away);
                        speed[i] = home.getCharacter(i).Dex;
                        response += killed(speed);
                    }
                }
                ((BattleViewForm)(State.currentStateView())).refreshView();
            }

            for (int i = 0; i < away.size(); i++)
            {
                int ix = i + home.size();
                if (speed[ix] != 0)
                    speed[ix]--;
                else
                {
                    if (home.size() > 0)
                    {
                        away.getCharacter(i).turn(away, home);
                        speed[ix] = home.getCharacter(i).Dex;
                        response += killed(speed);
                    }
                }
                ((BattleViewForm)(State.currentStateView())).refreshView();
            }
            if (home.size() == 0)
            {
                response += ("You lost...");
                this.fighting = false;
            }
            else if (away.size() == 0)
            {
				foreach (Character him in home)
					him.levelUp ();
                response += ("You won!");
                this.fighting = false;
            }
            return response;
        }
        /*public String battle()
        {
            while (home.size() > 0 && away.size() > 0)
            {
                for (int i = 0; i < home.size(); i++)
                {
                    if (speed[i] != 0)
                        speed[i]--;
                    else
                    {
                        if (away.size() > 0)
                        {
                            IAbility action;
                            action = home.getCharacter(i).turn(home, away);
                            action.ability(away);
                            speed[i] = home.getCharacter(i).Dex;
                            killed(speed);
                        }
                    }
                    ((BattleViewForm)(State.currentStateView())).refreshView();
                }

                for (int i = 0; i < away.size(); i++)
                {
                    int ix = i + home.size();
                    if (speed[ix] != 0)
                        speed[ix]--;
                    else
                    {
                        if (home.size() > 0)
                        {
                            away.getCharacter(i).turn(away, home);
                            speed[ix] = home.getCharacter(i).Dex;
                            killed(speed);
                        }
                    }
                    ((BattleViewForm)(State.currentStateView())).refreshView();
                }
            }
            String response = ("The battle is over.\n");
            if (home.size() == 0)
                return response + ("You lost...");
            else
                return response + ("You won!");
        }*/

        private string killed( List<int> speed )
        {
            string response = "";
            for( int i = 0 ; i < speed.Count ; i++)
            {
                if( i < home.size() )
                {
                    Character test = home.getCharacter(i);
                    if( test.HP <= 0 )
                    {
						test.defeat();
                        response += test.Name + " has been killed.\n";
                        speed.RemoveAt(i);
                        home.removeCharacter(i);
                        i--;
                    }
                }
                else
                {
                    int awayIx = i - home.size();
                    Character test = away.getCharacter(awayIx);
                    if (test.HP <= 0)
                    {
						test.defeat ();
                        response += test.Name + " has been killed.\n";
                        speed.RemoveAt(i);
                        away.removeCharacter(awayIx);
                        i--;
                    }
                }
            }
            return response;
        }
        public bool stillFighting()
        {
            return fighting;
        }
    }
}
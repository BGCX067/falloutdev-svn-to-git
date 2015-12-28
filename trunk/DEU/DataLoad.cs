using System;
using System.IO;
using System.Data.SqlClient;
using System.Reflection.Emit;
using fallserv;
using fallserv.ObjectClasses;

namespace DataExtractorUtility
{
	public class DataLoad
	{
		static void Main()
		{
			Item crit = new Item(ObjectType.Items, 395);
			crit.GetObjectProperties();
			return;
		}

//        class cItemArmor : cItem
//        {
//            public cItemArmor(int ObjectType, int ObjectID) : base(ObjectType, ObjectID)
//            {
//                vObjectType = ObjectType; // Тип объекта
//                vObjectID = ObjectID; // ID объекта
//            }
//            public int vTesla;
//            public int vAC;
//            public int vDRNormal;
//            public int vDRLaser;
//            public int vDRFire;
//            public int vDRPlasma;
//            public int vDRElectrical;
//            public int vDREMP;
//            public int vDRExplosion;
//            public int vDTNormal;
//            public int vDTLaser;
//            public int vDTFire;
//            public int vDTPlasma;
//            public int vDTElectrical;
//            public int vDTEMP;
//            public int vDTExplosion;
//            public int vPerk;
//            public int vMaleFrame;
//            public int vFemaleFrame;
//        }
//        class cItemDrug : cItem
//        {
//            public cItemDrug(int ObjectType, int ObjectID) : base(ObjectType, ObjectID)
//            {
//                vObjectType = ObjectType; // Тип объекта
//                vObjectID = ObjectID; // ID объекта
//            }
//            public int vStatID1;
//            public int vStatID2;
//            public int vStatID3;
//            public int vStatID1_Mod_Fast;
//            public int vStatID2_Mod_Fast;
//            public int vStatID3_Mod_Fast;
//            public int vMidTimeout;
//            public int vStatID1_Mod_Mid;
//            public int vStatID2_Mod_Mid;
//            public int vStatID3_Mod_Mid;
//            public int vLongTimeout;
//            public int vStatID1_Mod_Long;
//            public int vStatID2_Mod_Long;
//            public int vStatID3_Mod_Long;
//            public int vAddictionRate;
//            public int vPerk;
//            public int vAddictTime;
//        }
//        class cItemContainer : cItem
//        {
//            public cItemContainer(int ObjectType, int ObjectID)	: base(ObjectType, ObjectID)
//            {
//                vObjectType = ObjectType; // Тип объекта
//                vObjectID = ObjectID; // ID объекта
//            }
//            public int vSoundIDCont;
//            public int vTotalVolume;
//        }
//        class cItemMisc : cItem
//        {
//            public cItemMisc(int ObjectType, int ObjectID) : base(ObjectType, ObjectID)
//            {
//                vObjectType = ObjectType; // Тип объекта
//                vObjectID = ObjectID; // ID объекта
//            }
//            public int vSoundIDMisc;
//            public int vAmmoID;
//            public int vCaliberType;
//            public int vCharge;
//        }


//        // Выполнение команды SQL
//        public static void dbExec(string myExecuteQuery, SqlConnection myConnection)
//        {
//            myConnection.Open();
//            SqlCommand myCommand = new SqlCommand(myExecuteQuery, myConnection);
//            myCommand.ExecuteNonQuery();
//            myConnection.Close();
//        }

//        // Выполнение запроса SQL
//        public static void dbRead(string mySelectQuery, SqlConnection myConnection)
//        {
//            myConnection.Open();
//            SqlCommand myCommand = new SqlCommand(mySelectQuery, myConnection);
//            SqlDataReader myReader = myCommand.ExecuteReader();
//            while (myReader.Read())
//            {
///*				Console.WriteLine(myReader.GetSqlInt16(0));
//                Console.WriteLine(myReader.GetSqlInt32(1));
//                Console.WriteLine(myReader.GetSqlDecimal(2));
//                Console.WriteLine(myReader.GetString(3));
//                Console.WriteLine(myReader.GetString(4));
//*/			}
//            myReader.Close();
//            myConnection.Close();
//        }
//        // Главный цикл сервера
//        static void Main()
//        {
//            string query;
//            int k;
//            SqlConnection sqlConn = new SqlConnection("Integrated Security=SSPI;Persist Security Info=True;Initial Catalog=fallout;Data Source=ARTEM;Packet Size=4096;Workstation ID=ARTEM;");
//            int o = 0;
//            switch (o)
//            {
//                case 0:
//                    k = 531;
//                    query = @"DELETE FROM items;";
//                    dbExec(query, sqlConn);
//                    for (int i = 1; i <= k; i++)
//                    {
//                        cItem item = new cItem(o, i);
//                        item.mGetObjProps();
//                        #region Items SQL
//                        query = @"INSERT INTO items (
//							ObjectType, 
//							ObjectID, 
//							ObjectFullID, 
//							ObjectName, 
//							ObjectDesc, 
//							FrameIDType, 
//							FrameIDOffset, 
//							FrameID, 
//							FrameID1, 
//							LightDistance, 
//							LightIntensity,
//							AttackMode1,
//							AttackMode2,
//							ScriptID,
//							ObjectSubtype,
//							MaterialType,
//							Volume,
//							Weight,
//							BasePrice,
//							FrameInventIDType,
//							FrameInventID,
//							SoundID
//						) VALUES (" + 
//                            item.vObjectType + ", " + 
//                            item.vObjectID + ", " + 
//                            item.vObjectID + "00, '" + 
//                            item.vObjectName.Replace("'", " ") + "','" + 
//                            item.ObjectDesc.Replace("'", " ") + "'" + "," + 
//                            item.vFrameIDType + ", " + 
//                            item.vFrameIDOffset + ", '" + 
//                            item.vObjectFrame.Replace(".frm", "").Trim() + "', " + 
//                            item.vFrameID + ", " + 
//                            item.vLightDistance + ", " + 
//                            item.vLightIntensity + ", " +
//                            item.vAttackMode1 + "," +
//                            item.vAttackMode2 + "," +
//                            item.vScriptID + "," +
//                            item.vObjectSubtype + "," +
//                            item.vMaterialType + "," +
//                            item.vVolume + "," +
//                            item.vWeight + "," +
//                            item.vBasePrice + "," +
//                            item.vInvenID + "," +
//                            item.vInvenFrame + "," +
//                            item.vSoundID
//                            + ");";
//                        #endregion
//                        dbExec(query, sqlConn);
//                    }
//                    break;
//                case 1:
//                    k = 483;
//                    query = @"DELETE FROM critters;";
//                    dbExec(query, sqlConn);
//                    for (int i = 1; i <= k; i++)
//                    {
//                        Critter item = new Critter(o, i);
//                        item.mGetObjProps();
//                        #region Critters SQL
//                        query = @"INSERT INTO critters (ObjectType, ObjectID, ObjectFullID, ObjectName, ObjectDescription, FrameIDType, FrameIDOffset, FrameID, FrameID1, LightDistance, LightIntensity, 
//										ScriptID, 
//										TalkingHeadFrame, 
//										AIPaket_num, 
//										TeamNumber, 
//										Strength, 
//										Perception, 
//										Endurance, 
//										Charisma, 
//										Intelligence, 
//										Agility, 
//										Luck, 
//										HP, 
//										AP, 
//										AC, 
//										UnarmedDamage, 
//										MeleeDamage, 
//										CarryWeight, 
//										Sequence, 
//										HealingRate, 
//										CriticalChance, 
//										BetterCriticals, 
//										DT_Normal, 
//										DT_Laser, 
//										DT_Fire, 
//										DT_Plasma, 
//										DT_Electrical, 
//										DT_EMP, 
//										DT_Explode, 
//										DR_Normal, 
//										DR_Laser, 
//										DR_Fire, 
//										DR_Plasma, 
//										DR_Electrical, 
//										DR_EMP, 
//										DR_Explode, 
//										DR_Radiation, 
//										DR_Poison, 
//										BaseAge, 
//										BaseSex, 
//										ExtraStrenght, 
//										ExtraPerception, 
//										ExtraEndurance, 
//										ExtraCharisma, 
//										ExtraIntelligence, 
//										ExtraAgility, 
//										ExtraLuck, 
//										ExtraHP, 
//										ExtraAP, 
//										ExtraAC, 
//										ExtraUnarmedDamage, 
//										ExtraMeleeDamage, 
//										ExtraCarryWeight, 
//										ExtraSequence, 
//										ExtraHealingRate, 
//										ExtraCriticalChance, 
//										ExtraBetterCriticals, 
//										ExtraDT_Normal, 
//										ExtraDT_Laser, 
//										ExtraDT_Fire, 
//										ExtraDT_Plasma, 
//										ExtraDT_Electrical, 
//										ExtraDT_EMP, 
//										ExtraDT_Explode, 
//										ExtraDR_Normal, 
//										ExtraDR_Laser, 
//										ExtraDR_Fire, 
//										ExtraDR_Plasma, 
//										ExtraDR_Electrical, 
//										ExtraDR_EMP, 
//										ExtraDR_Explode, 
//										ExtraDR_Radiation, 
//										ExtraDR_Poison, 
//										ExtraAge, 
//										ExtraSex, 
//										Skill_SmallGuns, 
//										Skill_BigGuns, 
//										Skill_EnergyWeapons, 
//										Skill_Unarmed, 
//										Skill_Melee, 
//										Skill_Throwing, 
//										Skill_FirstAid, 
//										Skill_Doctor, 
//										Skill_Sneak, 
//										Skill_Lockpick, 
//										Skill_Steal, 
//										Skill_Traps, 
//										Skill_Science, 
//										Skill_Repair, 
//										Skill_Speech, 
//										Skill_Barter, 
//										Skill_Gambling, 
//										Skill_Outdoorsmanship, 
//										BodyType, 
//										XPForKill,
//										KillType,
//										DamageType
//										) VALUES 
//										(" + item.vObjectType + ", " + 
//                                        item.vObjectID + ", " + 
//                                        item.vObjectID + "00, '" + 
//                                        item.vObjectName.Replace("'", " ") + "','" + 
//                                        item.ObjectDesc.Replace("'", " ") + "'" + "," + 
//                                        item.vFrameIDType + ", " + 
//                                        item.vFrameIDOffset + ", '" + 
//                                        item.vObjectFrame.Replace(".frm", "").Trim() + "', " + 
//                                        item.vFrameID + ", " + item.vLightDistance + ", " + 
//                                        item.vLightIntensity + ", " +
//                                        item.vScriptID + ", " +
//                                        item.vTalkingHeadFrame + ", " +
//                                        item.vAIPaket_num + ", " +
//                                        item.vTeamNumber + ", " +
//                                        item.vStrenght + ", " +
//                                        item.vPerception + ", " +
//                                        item.vEndurance + ", " +
//                                        item.vCharisma + ", " +
//                                        item.vIntelligence + ", " +
//                                        item.vAgility + ", " +
//                                        item.vLuck + ", " +
//                                        item.vHP + ", " +
//                                        item.vAP + ", " +
//                                        item.vAC + ", " +
//                                        item.vUnarmedDamage + ", " +
//                                        item.vMeleeDamage + ", " +
//                                        item.vCarryWeight + ", " +
//                                        item.vSequence + ", " +
//                                        item.vHealingRate + ", " +
//                                        item.vCriticalChance + ", " +
//                                        item.vBetterCriticals + ", " +
//                                        item.vDT_Normal + ", " +
//                                        item.vDT_Laser + ", " +
//                                        item.vDT_Fire + ", " +
//                                        item.vDT_Plasma + ", " +
//                                        item.vDT_Electrical + ", " +
//                                        item.vDT_EMP + ", " +
//                                        item.vDT_Explode + ", " +
//                                        item.vDR_Normal + ", " +
//                                        item.vDR_Laser + ", " +
//                                        item.vDR_Fire + ", " +
//                                        item.vDR_Plasma + ", " +
//                                        item.vDR_Electrical + ", " +
//                                        item.vDR_EMP + ", " +
//                                        item.vDR_Explode + ", " +
//                                        item.vDR_Radiation + ", " +
//                                        item.vDR_Poison + ", " +
//                                        item.vBaseAge + ", " +
//                                        item.vBaseSex + ", " +
//                                        item.vExtraStrenght + ", " +
//                                        item.vExtraPerception + ", " +
//                                        item.vExtraEndurance + ", " +
//                                        item.vExtraCharisma + ", " +
//                                        item.vExtraIntelligence + ", " +
//                                        item.vExtraAgility + ", " +
//                                        item.vExtraLuck + ", " +
//                                        item.vExtraHP + ", " +
//                                        item.vExtraAP + ", " +
//                                        item.vExtraAC + ", " +
//                                        item.vExtraUnarmedDamage + ", " +
//                                        item.vExtraMeleeDamage + ", " +
//                                        item.vExtraCarryWeight + ", " +
//                                        item.vExtraSequence + ", " +
//                                        item.vExtraHealingRate + ", " +
//                                        item.vExtraCriticalChance + ", " +
//                                        item.vExtraBetterCriticals + ", " +
//                                        item.vExtraDT_Normal + ", " +
//                                        item.vExtraDT_Laser + ", " +
//                                        item.vExtraDT_Fire + ", " +
//                                        item.vExtraDT_Plasma + ", " +
//                                        item.vExtraDT_Electrical + ", " +
//                                        item.vExtraDT_EMP + ", " +
//                                        item.vExtraDT_Explode + ", " +
//                                        item.vExtraDR_Normal + ", " +
//                                        item.vExtraDR_Laser + ", " +
//                                        item.vExtraDR_Fire + ", " +
//                                        item.vExtraDR_Plasma + ", " +
//                                        item.vExtraDR_Electrical + ", " +
//                                        item.vExtraDR_EMP + ", " +
//                                        item.vExtraDR_Explode + ", " +
//                                        item.vExtraDR_Radiation + ", " +
//                                        item.vExtraDR_Poison + ", " +
//                                        item.vExtraAge + ", " +
//                                        item.vExtraSex + ", " +
//                                        item.vSkill_SmallGuns + ", " +
//                                        item.vSkill_BigGuns + ", " +
//                                        item.vSkill_EnergyWeapons + ", " +
//                                        item.vSkill_Unarmed + ", " +
//                                        item.vSkill_Melee + ", " +
//                                        item.vSkill_Throwing + ", " +
//                                        item.vSkill_FirstAid + ", " +
//                                        item.vSkill_Doctor + ", " +
//                                        item.vSkill_Sneak + ", " +
//                                        item.vSkill_Lockpick + ", " +
//                                        item.vSkill_Steal + ", " +
//                                        item.vSkill_Traps + ", " +
//                                        item.vSkill_Science + ", " +
//                                        item.vSkill_Repair + ", " +
//                                        item.vSkill_Speech + ", " +
//                                        item.vSkill_Barter + ", " +
//                                        item.vSkill_Gambling + ", " +
//                                        item.vSkill_Outdoorsmanship + ", " +
//                                        item.vBodyType + ", " +
//                                        item.vXPForKill + ", " +
//                                        item.vKillType + ", " +
//                                        item.vDamageType + ");";
//                        #endregion
//                        dbExec(query, sqlConn);
//                    }
//                    break;
//                case 2:
//                    k = 1851;
//                    query = @"DELETE FROM scenery;";
//                    dbExec(query, sqlConn);
//                    for (int i = 1; i <= k; i++)
//                    {
//                        Scenery item = new Scenery(o, i);
//                        item.mGetObjProps();
//                        #region Scenery SQL
//                        query = @"INSERT INTO scenery (
//							ObjectType, 
//							ObjectID, 
//							ObjectFullID, 
//							ObjectName, 
//							ObjectDescription, 
//							FrameIDType, 
//							FrameIDOffset, 
//							FrameID, 
//							FrameID1, 
//							LightDistance,
//							LightIntensity, 
//							ScriptID, 
//							SceneryType, 
//							MaterialType, 
//							SoundID, 
//							Availability
//							) VALUES (" + 
//                            item.vObjectType + ", " + 
//                            item.vObjectID + ", " + 
//                            item.vObjectID + "00, '" + 
//                            item.vObjectName.Replace("'", " ") + "','" + 
//                            item.ObjectDesc.Replace("'", " ") + "'" + "," + 
//                            item.vFrameIDType + ", " + 
//                            item.vFrameIDOffset + ", '" + 
//                            item.vObjectFrame.Replace(".frm", "").Trim() + "', " + 
//                            item.vFrameID + ", " + 
//                            item.vLightDistance + ", " + 
//                            item.vLightIntensity + ", " + 
//                            item.vScriptID + ", " + 
//                            item.vSceneryType + ", " + 
//                            item.vMaterialType + ", " + 
//                            item.vSoundID + ", " + 
//                            item.vAvailability + ");";
//                        #endregion
//                        dbExec(query, sqlConn);
//                    }
//                    break;
//                case 3:
//                    k = 1633;
//                    query = @"DELETE FROM walls;";
//                    dbExec(query, sqlConn);
//                    for (int i = 1; i <= k; i++)
//                    {
//                        Wall item = new Wall(o, i);
//                        item.mGetObjProps();
//                        #region Walls SQL
//                        query = @"INSERT INTO walls (
//									ObjectType, 
//									ObjectID, 
//									ObjectFullID, 
//									ObjectName, 
//									ObjectDescription, 
//									FrameIDType, 
//									FrameIDOffset, 
//									FrameID, 
//									FrameID1, 
//									LightDistance, 
//									LightIntensity, 
//									Side, 
//									ScriptID, 
//									MaterialType
//								) VALUES (" + 
//                                    item.vObjectType + ", " + 
//                                    item.vObjectID + ", " + 
//                                    item.vObjectID + "00, '" + 
//                                    item.vObjectName.Replace("'", " ") + "','" + 
//                                    item.ObjectDesc.Replace("'", " ") + "'" + "," + 
//                                    item.vFrameIDType + ", " + 
//                                    item.vFrameIDOffset + ", '" + 
//                                    item.vObjectFrame.Replace(".frm", "").Trim() + "', " + 
//                                    item.vFrameID + ", " + 
//                                    item.vLightDistance + ", " + 
//                                    item.vLightIntensity + ", " + 
//                                    item.vWallSide + ", " + 
//                                    item.ScriptId + ", " + 
//                                    item.vMaterialType + ");";
//                        #endregion
//                        dbExec(query, sqlConn);
//                    }
//                    break;
//                case 4:
//                    k = 3102;
//                    query = @"DELETE FROM tiles;";
//                    dbExec(query, sqlConn);
//                    for (int i = 1; i <= k; i++)
//                    {
//                        Tile item = new Tile(o, i);
//                        item.mGetObjProps();
//                        query = @"INSERT INTO tiles (ObjectType, ObjectID, ObjectFullID, ObjectName, ObjectDescription, FrameIDType, FrameIDOffset, FrameID, FrameID1, LightDistance, LightIntensity) VALUES (" + item.vObjectType + ", " + item.vObjectID + ", " + item.vObjectID + "00, '" + item.vObjectName.Replace("'", " ") + "','" + item.ObjectDesc.Replace("'", " ") + "'" + "," + item.vFrameIDType + ", " + item.vFrameIDOffset + ", '" + item.vObjectFrame.Replace(".frm", "").Trim() + "', " + item.vFrameID + ", " + item.vLightDistance + ", " + item.vLightIntensity + ");";
//                        dbExec(query, sqlConn);
//                    }
//                    break;
//                case 5:
//                    k = 50;
//                    query = @"DELETE FROM misc;";
//                    dbExec(query, sqlConn);
//                    for (int i = 1; i <= k; i++)
//                    {
//                        Tile item = new Tile(o, i);
//                        item.mGetObjProps();
//                        query = @"INSERT INTO misc (ObjectType, ObjectID, ObjectFullID, ObjectName, ObjectDescription, FrameIDType, FrameIDOffset, FrameID, FrameID1, LightDistance, LightIntensity) VALUES (" + item.vObjectType + ", " + item.vObjectID + ", " + item.vObjectID + "00, '" + item.vObjectName.Replace("'", " ") + "','" + item.ObjectDesc.Replace("'", " ") + "'" + "," + item.vFrameIDType + ", " + item.vFrameIDOffset + ", '" + item.vObjectFrame.Replace(".frm", "").Trim() + "', " + item.vFrameID + ", " + item.vLightDistance + ", " + item.vLightIntensity + ");";
//                        dbExec(query, sqlConn);
//                    }
//                    break;
//                default:
//                    k = 531;
//                    break;
//            }
//        }
	}
}
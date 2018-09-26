using FlatBuffers;
using System;
using MyGame.Sample;
using System.IO;
using System.Diagnostics;

namespace FlatBuffer
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                var builder = new FlatBufferBuilder(1);
                var pos = Abc.CreateAbc(builder, 1, 2, 3);
                builder.Finish(pos.Value);
                byte[] data = new byte[builder.Offset];
                Buffer.BlockCopy(builder.DataBuffer.Data, builder.DataBuffer.Position, data, 0, data.Length);
                var bf = new ByteBuffer(data);
                Abc aes =Abc.GetRootAsAbc(bf);
            }
            sw.Stop();
            var abc = sw.Elapsed.TotalSeconds;
            int ae = 1;
            //var weaponOneName = builder.CreateString("Sword");
            //var weaponOneDamage = 3;
            //var weaponTwoName = builder.CreateString("Axe");
            //var weaponTwoDamage = 5;
            //var sword = Weapon.CreateWeapon(builder, weaponOneName, (short)weaponOneDamage);
            //var axe = Weapon.CreateWeapon(builder, weaponTwoName, (short)weaponTwoDamage);
            //var name = builder.CreateString("Orc");
            //// 创建一个矢量来表示会掉落的物品，  
            //// 每一个数字都可以和一个道具通信。在兽人死后，对应的道具就会被声明。  
            ////注意：我们放入byte的顺序，和取出来的时候是反的（比如我先放入的是9，但是数组里第9个才是9）
            //Monster.StartInventoryVector(builder, 10);
            //for (int i = 9; i >= 0; i--)
            //{
            //    builder.AddByte((byte)i);
            //}
            //var inv = builder.EndVector();

            //var weaps = new Offset<Weapon>[2];
            //weaps[0] = sword;
            //weaps[1] = axe;
            //// Pass the `weaps` array into the `CreateWeaponsVector()` method to create a FlatBuffer vector.  
            //var weapons = Monster.CreateWeaponsVector(builder, weaps);

            //var pos = Vec3.CreateVec3(builder, 1.0f, 2.0f, 3f);

            //Monster.StartMonster(builder);
            //Monster.AddPos(builder, pos);
            //Monster.AddHp(builder, (short)300);
            //Monster.AddName(builder, name);
            //Monster.AddInventory(builder, inv);
            //Monster.AddColor(builder, Color.Red);
            //Monster.AddWeapons(builder, weapons);
            //Monster.AddEquippedType(builder, Equipment.Weapon);
            //Monster.AddEquipped(builder, axe.Value); // Union类型包含两个字段。  
            //var orc = Monster.EndMonster(builder);
            //builder.Finish(orc.Value);

            //byte[] data = new byte[builder.Offset];
            //Buffer.BlockCopy(builder.DataBuffer.Data, builder.DataBuffer.Position, data, 0, data.Length);







        }
    }
}

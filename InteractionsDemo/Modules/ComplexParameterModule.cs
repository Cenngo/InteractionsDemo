using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractionsDemo.Modules
{
    public class ComplexParameterModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("create-vector", "create 3d vector")]
        public async Task CreateVector([ComplexParameter]Vector3 vector)
        {
            await RespondAsync(vector.ToString());
        }

        [SlashCommand("get-timespan", "get TimeSpan")]
        public async Task GetTimeSpan([ComplexParameter(new Type[] {typeof(int), typeof(int), typeof(int)})]TimeSpan timespan)
        {
            await RespondAsync(timespan.ToString());
        }
    }

    public class Vector3
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        [ComplexParameterCtor]
        public Vector3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString() => $"x= {X}, y= {Y}, z= {Z}";
    }
}

using System;
using System.Collections.Generic;
using System.Reflection;
using YooAsset;

namespace ET.Client
{
    public partial class CodeLoader
    {
        public byte[] dllBytes;
        public byte[] pdbBytes;
                
        public async ETTask LoadCodeByYooooo()
        {
            await LoadDllAndPdb("Model");
            this.model = Assembly.Load(dllBytes, pdbBytes);
            try
            {
                await LoadHotfixByYooooo();
                IStaticMethod start = new StaticMethod(model, "ET.Entry", "Start");
                start?.Run();
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
        }

        public async ETTask LoadHotfixByYooooo()
        {
            // await LoadDllAndPdb("Hotfix");
            // Assembly hotfixAssembly = Assembly.Load(this.dllBytes, this.pdbBytes);
            // Log.Info($"hotfixAssembly {hotfixAssembly}");
            // Dictionary<string, Type> types = AssemblyHelper.GetAssemblyTypes(typeof (Game).Assembly, typeof(Init).Assembly, this.model, hotfixAssembly);
            // EventSystem.Instance.Add(types);
            // Log.Info($"Hotfix Types {types.Count}");
        }

        public async ETTask LoadDllAndPdb(string CodeName)
        {
            var dll = YooAssetProxy.Default.LoadRawFileSync($"{CodeName}.dll");
            dllBytes = dll.GetRawFileData();
            Log.Info($"{CodeName} dll {this.dllBytes.Length}");
            
            var pdb = YooAssetProxy.Default.LoadRawFileSync($"{CodeName}.pdb");
            pdbBytes = pdb.GetRawFileData();
            Log.Info($"{CodeName} pdb {this.pdbBytes.Length}");
        }
    }
}


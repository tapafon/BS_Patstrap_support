using System.Runtime.CompilerServices;
using IPA.Config.Stores;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace BS_Patstrap_support.Configuration
{
    internal class PluginConfig
    {
        public static PluginConfig Instance { get; set; }
        public virtual int AddressOne { get; set; } = 127; // Must be 'virtual' if you want BSIPA to detect a value change and save the config automatically.
        public virtual int AddressTwo { get; set; } = 0;
        public virtual int AddressThree { get; set; } = 0;
        public virtual int AddressFour { get; set; } = 1;


        /// <summary>
        /// This is called whenever BSIPA reads the config from disk (including when file changes are detected).
        /// </summary>
        public virtual void OnReload()
        {
            // Do stuff after config is read from disk.
        }

        /// <summary>
        /// Call this to force BSIPA to update the config file. This is also called by BSIPA if it detects the file was modified.
        /// </summary>
        public virtual void Changed()
        {
            // Do stuff when the config is changed.
        }

        /// <summary>
        /// Call this to have BSIPA copy the values from <paramref name="other"/> into this config.
        /// </summary>
        public virtual void CopyFrom(PluginConfig other)
        {
            // This instance's members populated from other
        }
    }
}

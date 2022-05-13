﻿using KAST.Core.Managers;
using SteamKit2.Internal;
using System.Diagnostics;

namespace KAST.Core.Models
{
    public class Mod
    {
        /// <summary>
        /// Constructor for mods with an ID (Steam Workshop mods)
        /// </summary>
        /// <param name="id"></param>
        public Mod(ulong id)
        {
            ModID = id;
        }


        /// <summary>
        /// Constructor for Local Mods.
        /// </summary>
        /// <remarks>
        /// The <see cref="ModID">mod's ID</see> is automatically calculated from a random number between <c><see cref="ulong.MaxValue"/></c> and <c><see cref="ulong.MaxValue"/> - 65535</c>
        /// </remarks>
        public Mod()
        {
            using var c = new KastContext();
            do
                ModID = ulong.MaxValue - (ulong)Random.Shared.Next(ushort.MaxValue);
            while(c.Mods.Any(m => m.ModID == ModID));
        }
        

        private ulong       _ID;
        private string?     name;
        private string?     url;
        private string?     path;
        private DateTime?   steamLastUpdated;
        private DateTime?   localLastUpdated;
        private bool?       isLocal;
        private string?     status;
        private ulong?      expectedSize;
        private ulong?      actualSize;

        /// <summary>
        /// The mod's ID
        /// </summary>
        /// <remarks>
        ///     <para>
        ///     If the Mod is a Workshop mod, the mod ID will be the mod's ID on the workshop
        ///     </para>
        ///     <para>
        ///     If the mod is a Local mod, the ID will be randomly generated
        ///     </para>
        /// </remarks>
        public ulong ModID
        {
            get { return _ID; }
            private set { _ID = value; }
        }

        /// <summary>
        /// THe mod's name on the Workshop
        /// </summary>
        public string? Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Steam Workshop of the Mod
        /// </summary>
        public string? Url
        {
            get { return url; }
            set { url = value; }
        }

        /// <summary>
        /// Author of the mod
        /// </summary>
        public virtual Author? Author
        {
            get;
            set;
        }

        /// <summary>
        /// Current path of the Mod
        /// </summary>
        public string? Path
        {
            get { return path; }
            set { path = value; }
        }


        /// <summary>
        /// When was the mod updater on the Steam Workshop
        /// </summary>
        public DateTime? SteamLastUpdated
        {
            get { return steamLastUpdated; }
            set { steamLastUpdated = value; }
        }

        /// <summary>
        /// When was the mod updated on the server
        /// </summary>
        public DateTime? LocalLastUpdated
        {
            get { return localLastUpdated; }
            set { localLastUpdated = value; }
        }

        /// <summary>
        /// Checks if the mod is local or not
        /// </summary>
        public bool? IsLocal
        { get { return isLocal; } set { isLocal = value; } }

        /// <summary>
        /// Current status of the mod
        /// </summary>
        public string? ModStatus
        { get { return status; } set { status = value; } }

        /// <summary>
        /// Expected size of the mod on the Disk (Filled from Steam Workshop)
        /// </summary>
        public ulong? ExpectedSize
        { get { return expectedSize; } set { expectedSize = value; } }

        /// <summary>
        /// Actual size of the mod on the Disk
        /// </summary>
        public ulong? ActualSize
        { get { return actualSize; } set { actualSize = value; } }

        /// <summary>
        /// Returns whether or not the mod exists in the Database
        /// </summary>
        /// <returns></returns>
        internal bool Exists()
        {
            using var c = new KastContext();
            return c.Mods.FirstOrDefault(m => m.ModID == ModID) != null;
        }

        /// <summary>
        /// Return the instance of the mod from the Database
        /// </summary>
        /// <returns></returns>
        internal Mod? GetDbItem()
        {
            using var c = new KastContext();
            return c.Mods.FirstOrDefault(m => m.ModID == ModID);
        }

        /// <summary>
        /// Update a mod's infos from the UpdateManager
        /// </summary>
        /// <returns></returns>
        internal async Task UpdateModInfos()
        {
            UpdateManager updater = new();
            PublishedFileDetails res;
            try
            {
                res = await updater.GetModInfo(ModID);
            }
            catch (KastLogonFailedException)
            { Debug.WriteLine("Logon Failed"); return; }
            catch (Exception ex)
            { Debug.WriteLine(ex.ToString()); return; }
            

            Name = res.title;
            SteamLastUpdated = Utilities.UnixTimeStampToDateTime(res.time_updated);
            ExpectedSize = res.file_size;
        }

        /// <summary>
        /// Update a mod using the UpdateManager
        /// </summary>
        /// <returns></returns>
        internal async Task UpdateMod()
        {
            UpdateManager updater = new();
            await updater.UpdateMod(ModID);
        }
    }
}
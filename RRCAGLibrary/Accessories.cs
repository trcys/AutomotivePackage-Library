/*
 * Name: Tracy Salak
 * Program: Business Information Technology
 * Course: ADEV-2008 Programming 2
 * Created: 2021-01-12
 * Updated: 2021-01-31
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salak.Tracy.Business
{
    /// <summary>
    /// List of accessories to choose from.
    /// </summary>
    public enum Accessories
    {
        /// <summary>
        /// No accessories chosen.
        /// </summary>
        None,

        /// <summary>
        /// Stereo system chosen.
        /// </summary>
        StereoSystem,

        /// <summary>
        /// Leather interior chosen.
        /// </summary>
        LeatherInterior,

        /// <summary>
        /// Stereo and leather interior chosen.
        /// </summary>
        StereoAndLeather,

        /// <summary>
        /// Computer navigation chosen.
        /// </summary>
        ComputerNavigation,

        /// <summary>
        /// Stereo and navigation chosen.
        /// </summary>
        StereoAndNavigation,

        /// <summary>
        /// Leather and navigation chosen.
        /// </summary>
        LeatherAndNavigation,

        /// <summary>
        /// All accessories are chosen.
        /// </summary>
        All
    }
}

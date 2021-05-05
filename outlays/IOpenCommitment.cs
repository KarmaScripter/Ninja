﻿// <copyright file = "IOpenCommitment.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    using System;

    // ******************************************************************************************************************************
    // ******************************************************   ASSEMBLIES   ********************************************************
    // ******************************************************************************************************************************
    /// <summary>
    /// </summary>
    /// <seealso cref = "ICommitment"/>
    public interface IOpenCommitment : ICommitment
    {
        // ***************************************************************************************************************************
        // ************************************************  METHODS   ***************************************************************
        // ***************************************************************************************************************************

        /// <summary>
        /// Gets the open commitment amount.
        /// </summary>
        /// <returns>
        /// </returns>
        IAmount GetOpenCommitmentAmount();
    }
}

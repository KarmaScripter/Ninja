﻿// <copyright file = "Computation.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace BudgetExecution
{
    // **************************************************************************************************************************
    // ********************************************      ASSEMBLIES    **********************************************************
    // **************************************************************************************************************************

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public class Computation : Builder, IDataFilter
    {
        // **************************************************************************************************************************
        // ********************************************      FIELDS     *************************************************************
        // **************************************************************************************************************************

        // **************************************************************************************************************************
        // ********************************************   CONSTRUCTORS     **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Initializes a new instance of the <see cref = "Computation"/> class.
        /// </summary>
        public Computation()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Computation"/> class.
        /// </summary>
        /// <param name = "data" >
        /// The data.
        /// </param>
        public Computation( IDataAccess data )
        {
            Data = data.GetData();
        }

        // **************************************************************************************************************************
        // ********************************************      PROPERTIES    **********************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        private IEnumerable<DataRow> Data { get; }

        // **************************************************************************************************************************
        // ********************************************      METHODS    *************************************************************
        // **************************************************************************************************************************

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name = "field" >
        /// The field.
        /// </param>
        /// <param name = "filter" >
        /// </param>
        /// <returns>
        /// </returns>
        public IEnumerable<DataRow> FilterData( Field field, string filter )
        {
            if( GetData()?.Any() == true
                && Enum.IsDefined( typeof( Field ), field )
                && Verify.Input( filter ) )
            {
                try
                {
                    var query = GetData()
                        .Where( p => p.Field<string>( $"{field}" ).Equals( filter ) )
                        .Select( p => p );

                    return query.Any()
                        ? query.ToArray()
                        : default;
                }
                catch( Exception ex )
                {
                    Fail( ex );
                    return default;
                }
            }

            return default;
        }

        /// <summary>
        /// Get Error Dialog.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private protected static void Fail( Exception ex )
        {
            using var error = new Error( ex );
            error?.SetText();
            error?.ShowDialog();
        }
    }
}

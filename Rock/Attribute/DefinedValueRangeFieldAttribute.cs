﻿// <copyright>
// Copyright 2013 by the Spark Development Network
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;

namespace Rock.Attribute
{
    /// <summary>
    /// Field Attribute to select a ranger of DefinedValues for the given DefinedType Guid.  Stored as comma-delimited pair of DefinedValue.Guids.
    /// </summary>
    [AttributeUsage( AttributeTargets.Class, AllowMultiple = true, Inherited = true )]
    public class DefinedValueRangeFieldAttribute : FieldAttribute
    {
        private const string DEFINED_TYPE_KEY = "definedtype";

        public DefinedValueRangeFieldAttribute( string definedTypeGuid, string name = "", string description = "", bool required = true, string defaultValue = "", string category = "", int order = 0, string key = null )
            : base( name, description, required, defaultValue, category, order, key, typeof( Rock.Field.Types.DefinedValueRangeFieldType ).FullName )
        {
            var definedType = Rock.Web.Cache.DefinedTypeCache.Read( new Guid( definedTypeGuid ) );
            if ( definedType != null )
            {
                var definedTypeConfigValue = new Field.ConfigurationValue( definedType.Id.ToString() );
                FieldConfigurationValues.Add( DEFINED_TYPE_KEY, definedTypeConfigValue );

                if ( string.IsNullOrWhiteSpace( Name ) )
                {
                    Name = definedType.Name;
                }

                if ( string.IsNullOrWhiteSpace( Key ) )
                {
                    Key = Name.Replace( " ", string.Empty );
                }
            }
        }
    }
}
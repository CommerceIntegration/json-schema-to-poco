﻿using System.CodeDom;
using Newtonsoft.Json.Linq;

namespace Cvent.SchemaToPoco.Json.Class.Property.Types
{
    /// <summary>
    /// Represents the integer schema property type. To handle all domains the type is represented as a long.
    /// </summary>
    class IntegerPropertyType : JsonSchemaPropertyType
    {
        /// <see cref="JsonSchemaPropertyType"/>
        public  override CodeTypeReference GetType(JsonPropertyInfo info)
        {
            return new CodeTypeReference(typeof(long));
        }

        /// <see cref="JsonSchemaPropertyType"/>
        public override CodeAssignStatement GetDefaultAssignment(JsonPropertyInfo info)
        {
            if (info.Definition.Default == null || info.Definition.Default.Type != JTokenType.Integer)
                return null;

            return CreatePrimitiveDefaultAssignment(info.FieldName, info.Definition.Default.Value<long>());
        }
    }
}

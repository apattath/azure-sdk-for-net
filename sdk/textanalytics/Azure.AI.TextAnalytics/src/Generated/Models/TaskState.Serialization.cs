// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    public partial class TaskState
    {
        internal static TaskState DeserializeTaskState(JsonElement element)
        {
            DateTimeOffset lastUpdateDateTime = default;
            Optional<string> name = default;
            OperationStatus status = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("lastUpdateDateTime"))
                {
                    lastUpdateDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("status"))
                {
                    status = new OperationStatus(property.Value.GetString());
                    continue;
                }
            }
            return new TaskState(lastUpdateDateTime, name.Value, status);
        }
    }
}

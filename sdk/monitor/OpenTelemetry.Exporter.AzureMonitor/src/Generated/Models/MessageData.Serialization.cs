// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace OpenTelemetry.Exporter.AzureMonitor.Models
{
    public partial class MessageData : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("ver");
            writer.WriteNumberValue(Ver);
            writer.WritePropertyName("message");
            writer.WriteStringValue(Message);
            if (Optional.IsDefined(SeverityLevel))
            {
                writer.WritePropertyName("severityLevel");
                writer.WriteStringValue(SeverityLevel.Value.ToString());
            }
            if (Optional.IsCollectionDefined(Properties))
            {
                writer.WritePropertyName("properties");
                writer.WriteStartObject();
                foreach (var item in Properties)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsCollectionDefined(Measurements))
            {
                writer.WritePropertyName("measurements");
                writer.WriteStartObject();
                foreach (var item in Measurements)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteNumberValue(item.Value);
                }
                writer.WriteEndObject();
            }
            if (Optional.IsDefined(Test))
            {
                writer.WritePropertyName("test");
                writer.WriteStringValue(Test);
            }
            writer.WriteEndObject();
        }

        internal static MessageData DeserializeMessageData(JsonElement element)
        {
            int ver = default;
            string message = default;
            Optional<SeverityLevel> severityLevel = default;
            Optional<IDictionary<string, string>> properties = default;
            Optional<IDictionary<string, double>> measurements = default;
            Optional<string> test = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ver"))
                {
                    ver = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("severityLevel"))
                {
                    severityLevel = new SeverityLevel(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("properties"))
                {
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetString());
                    }
                    properties = dictionary;
                    continue;
                }
                if (property.NameEquals("measurements"))
                {
                    Dictionary<string, double> dictionary = new Dictionary<string, double>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, property0.Value.GetDouble());
                    }
                    measurements = dictionary;
                    continue;
                }
                if (property.NameEquals("test"))
                {
                    test = property.Value.GetString();
                    continue;
                }
            }
            return new MessageData(test.Value, ver, message, Optional.ToNullable(severityLevel), Optional.ToDictionary(properties), Optional.ToDictionary(measurements));
        }
    }
}
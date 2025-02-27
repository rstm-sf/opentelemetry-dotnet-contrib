// Copyright The OpenTelemetry Authors
// SPDX-License-Identifier: Apache-2.0

using System;
using OpenTelemetry.Instrumentation.ElasticsearchClient.Implementation;

namespace OpenTelemetry.Instrumentation.ElasticsearchClient;

/// <summary>
/// OpenSearch client instrumentation.
/// </summary>
internal class ElasticsearchClientInstrumentation : IDisposable
{
    private readonly DiagnosticSourceSubscriber diagnosticSourceSubscriber;

    /// <summary>
    /// Initializes a new instance of the <see cref="ElasticsearchClientInstrumentation"/> class.
    /// </summary>
    /// <param name="options">Configuration options for OpenSearch client instrumentation.</param>
    public ElasticsearchClientInstrumentation(ElasticsearchClientInstrumentationOptions options)
    {
        this.diagnosticSourceSubscriber = new DiagnosticSourceSubscriber(new ElasticsearchRequestPipelineDiagnosticListener(options), null, ElasticsearchInstrumentationEventSource.Log.UnknownErrorProcessingEvent);
        this.diagnosticSourceSubscriber.Subscribe();
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        this.diagnosticSourceSubscriber.Dispose();
    }
}

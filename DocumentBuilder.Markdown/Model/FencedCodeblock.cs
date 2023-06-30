﻿using DocumentBuilder.Constants;
using System.Text;
using DocumentBuilder.Markdown.Options;

namespace DocumentBuilder.Markdown.Model;

internal class FencedCodeblock : IMarkdownElement
{
    private readonly string _codeblock;
    private readonly string? _language;

    public FencedCodeblock(string codeblock, string? language = null)
    {
        _codeblock = codeblock;
        _language = language;
    }

    public string ToMarkdown(MarkdownDocumentOptions options)
        => new StringBuilder()
        .Append(Indicators.Codeblock)
        .Append(_language)
        .Append(args.NewLineProvider.GetNewLine())
        .Append(_codeblock)
        .Append(args.NewLineProvider.GetNewLine())
        .Append(Indicators.Codeblock)
        .ToString();
}

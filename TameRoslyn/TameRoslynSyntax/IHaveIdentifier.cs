// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;

namespace Zu.TameRoslyn.Syntax
{
    public interface IHaveIdentifier
    {
        SyntaxToken Identifier { get; set; }
        string IdentifierStr { get; set; }
    }
}
/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */
namespace NativeFx.Entities;
/// <summary>
/// Represents an instance that can be deleted.
/// </summary>
public interface IDeletable
{
    /// <summary>
    /// Deletes this instance.
    /// </summary>
    void Delete();
}

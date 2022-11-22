/*
 * SPDX-FileCopyrightText: 2022 WithLithum <withlithum@foxmail.com>
 *
 * SPDX-License-Identifier: Apache-2.0
 */

namespace NativeFx.UI.Text;

public static class TextUtil
{
    public static bool DoesLabelExist(string name)
    {
        return Natives.DoesTextLabelExist(name);
    }
}
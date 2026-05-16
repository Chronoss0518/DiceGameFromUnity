using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

static public class MatrixExMethod
{

    static public Vector3 GetEulerRotationXYZ(this Matrix4x4 _matrix)
    {
        var res = Vector3.zero;
        var outM = CreateRotateMatrix(_matrix);
        res.y = MathF.Sin(-outM.m02);
        if (MathF.Abs(res.y) <= 0.0001f)
        {
            res.x = MathF.Atan(-outM.m21 / outM.m11);
            res.z = 0.0f;
        }
        else
        {
            res.x = MathF.Atan(outM.m12 / outM.m22);
            res.z = MathF.Atan(outM.m01 / outM.m00);
        }
        return res;
    }


    static public Vector3 GetEulerRotationXZY(this Matrix4x4 _matrix)
    {
        var res = Vector3.zero;
        var outM = CreateRotateMatrix(_matrix);
        res.z = MathF.Sin(outM.m01);
        if (MathF.Abs(res.z) <= 0.0001f)
        {
            res.x = MathF.Atan(outM.m12 / outM.m22);
            res.y = 0.0f;
        }
        else
        {
            res.x = MathF.Atan(-outM.m02 / outM.m22);
            res.y = MathF.Atan(-outM.m02 / outM.m00);
        }
        return res;
    }

    static public Vector3 GetEulerRotationYXZ(this Matrix4x4 _matrix)
    {

        var res = Vector3.zero;
        var outM = CreateRotateMatrix(_matrix);
        res.x = MathF.Sin(outM.m12);
        if (MathF.Abs(res.x) <= 0.0001f)
        {
            res.y = MathF.Atan(outM.m20 / outM.m00);
            res.z = 0.0f;
        }
        else
        {
            res.y = MathF.Atan(-outM.m02 / outM.m22);
            res.z = MathF.Atan(-outM.m10 / outM.m11);
        }
        return res;
    }


    static public Vector3 GetEulerRotationYZX(this Matrix4x4 _matrix)
    {

        var res = Vector3.zero;
        var outM = CreateRotateMatrix(_matrix);
        res.z = MathF.Sin(-outM.m10);
        if (MathF.Abs(res.z) <= 0.0001f)
        {
            res.x = 0.0f;
            res.y =MathF.Atan(-outM.m02 / outM.m22);
        }

        else
        {
            res.x =MathF.Atan(outM.m12 / outM.m11);
            res.y =MathF.Atan(outM.m20 / outM.m00);
        }
        return res;
    }

    static public Vector3 GetEulerRotationZXY(this Matrix4x4 _matrix)
    {

        var res = Vector3.zero;
        var outM = CreateRotateMatrix(_matrix);
        res.x = MathF.Sin(-outM.m21);
        if (MathF.Abs(res.x) <= 0.0001f)
        {
            res.y = 0.0f;
            res.z =MathF.Atan(-outM.m10 / outM.m00);
        }
        else
        {
            res.y =MathF.Atan(outM.m20 / outM.m22);
            res.z =MathF.Atan(outM.m01 / outM.m11);
        }
        return res;
    }

    static public Vector3 GetEulerRotationZYX(this Matrix4x4 _matrix)
    {
        var res = Vector3.zero;
        var outM = CreateRotateMatrix(_matrix);
        res.y = MathF.Sin(outM.m20);
        if (MathF.Abs(res.y) <= 0.0001f)
        {
            res.x = 0.0f;
            res.z =MathF.Atan(-outM.m10 / outM.m00);
        }
        else
        {
            res.x =MathF.Atan(outM.m21 / outM.m22);
            res.z =MathF.Atan(outM.m01 / outM.m11);
        }
        return res;
    }


    static private Matrix4x4 CreateRotateMatrix(this Matrix4x4 _mat)
    {
        Matrix4x4 res = Matrix4x4.zero;

        Vector3 tmp;
        tmp.x = _mat.m00;
        tmp.y = _mat.m01;
        tmp.z = _mat.m02;

        tmp.Normalize();

        res.m00 = tmp.x;
        res.m01 = tmp.y;
        res.m02 = tmp.z;

        tmp.x = _mat.m10;
        tmp.y = _mat.m11;
        tmp.z = _mat.m12;

        tmp.Normalize();

        res.m10 = tmp.x;
        res.m11 = tmp.y;
        res.m12 = tmp.z;

        tmp.x = _mat.m20;
        tmp.y = _mat.m21;
        tmp.z = _mat.m22;

        tmp.Normalize();

        res.m20 = tmp.x;
        res.m21 = tmp.y;
        res.m22 = tmp.z;

        return res;
    }

}

Shader "Ground/groundRaymarchTest"
{
    Properties
    {
        _LightStrength("Light Intensity", Float) = 1
        _MainTex ("groundHeightAdjust", 2D) = "white" {}
        _fogColor("fog Color", Color) = (1,1,1,1)
        _groundColor("ground Color", Color) = (1,1,1,1)
        _testSphereColor("sphere Color", Color) = (1,1,1,1)
        _scaleSize("env Scale", Vector) = (1,1,1,1)
        _testSphereLoc("test Sphere Location", Vector) = (0,0,0,0)
        _testSphereSize("test Sphere Size", Float) = 1
        _testGroundLoc("test Ground Location", Vector) = (0,0,0,0)
        _fogWeight("fog weight", Float) = 1
        _fogColorWeight("fog color weight", Float) = 1
        _StepCount("Steps to make", Int) = 8000
        _StepSize("Size of each step", float) = 0.1
    }
    SubShader
    {

        Tags {"Queue" = "Transparent"}
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 wPos : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.wPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            sampler2D _MainTex;
            float4 _testSphereColor;
            float4 _groundColor;
            float4 _fogColor;
            float4 _scaleSize;
            float3 _testSphereLoc;
            float _testSphereSize;
            float3 _testGroundLoc;
            float _fogWeight;
            float _fogColorWeight;
            float _LightStrength;

            int _StepCount;
            float _StepSize;

            bool SphereHit(float3 p, float3 center, float radius)
            {
                return distance(p, center) < radius;
            }

            bool GroundHit(float3 p, float height)
            {
                return p.y < height;
            }

            bool CylinderHit(float3 p, float3 center, float radius, float height)
            {
                return (distance(p.xz, center.xz) < radius) && (distance(p.y, center.y) < height);
            }

            bool CoralColumnHit(float3 p, float3 center, float radius, float height)
            {
                float3 centerOffset1 = (1, 1, 0);
                float3 centerOffset2 = (-1, 2, 2);
                float3 centerOffset3 = (1, 3, 1);
                float3 centerOffset4 = (1, 4, -1);
                float3 centerOffset5 = (0, 0, 0);

                float3 heightOffset1 = (0, 0, 0);
                float3 heightOffset2 = (0, 0, 0);
                float3 heightOffset3 = (0, 0, 0);
                float3 heightOffset4 = (0, 0, 0);
                float3 heightOffset5 = (0, 8, 0);

                float3 radiusOffset1 = (0, 0, 0);
                float3 radiusOffset2 = (0, 0, 0);
                float3 radiusOffset3 = (0, 0, 0);
                float3 radiusOffset4 = (0, 0, 0);
                float3 radiusOffset5 = (0, 0, 0);

                return (CylinderHit(p, (center + centerOffset1) * _scaleSize, (radius + radiusOffset1) * _scaleSize, (height + heightOffset1) * _scaleSize) || CylinderHit(p, (center + centerOffset2) * _scaleSize, (radius + radiusOffset2) * _scaleSize, (height + heightOffset2) * _scaleSize) || CylinderHit(p, (center + centerOffset3) * _scaleSize, (radius + radiusOffset3) * _scaleSize, (height + heightOffset3) * _scaleSize) || CylinderHit(p, (center + centerOffset4) * _scaleSize, (radius + radiusOffset4) * _scaleSize, (height + heightOffset4) * _scaleSize) || CylinderHit(p, (center + centerOffset5) * _scaleSize, (radius + radiusOffset5) * _scaleSize, (height + heightOffset5) * _scaleSize));
            }


            float4 RaymarchHit(float3 position, float3 direction)
            {
                for (int i = 0; i < _StepCount; i++)
                {
                    if (SphereHit(position, _testSphereLoc, _testSphereSize * _scaleSize.x) || GroundHit(position, _testGroundLoc.y))
                    {
                        return float4(position, 1);
                    }
                    if (CoralColumnHit(position, _testSphereLoc, 15 * _scaleSize.x, 1 * _scaleSize.x) || CoralColumnHit(position, _testSphereLoc + (100, 10, 10), 15 * _scaleSize.x, 1 * _scaleSize.x) || CoralColumnHit(position, _testSphereLoc + (100, 10, 10), 15 * _scaleSize.x, 1 * _scaleSize.x))
                    {
                        return float4(position, 3);
                    }

                    position += direction * _StepSize;
                }


                return float4(0,0,0,0);
            }




            fixed4 frag(v2f i) : SV_Target
            {
                float3 viewDirection = normalize(i.wPos - _WorldSpaceCameraPos);
                float3 worldPosition = i.wPos;
                float4 depth = RaymarchHit(worldPosition, viewDirection);

                half3 worldNormal = depth - _testSphereLoc;
                half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));

                if (length(depth) != 0)
                {
                    float4 color = (0,0,0,0);
                    if (depth.w == 1)
                    {
                        color = _groundColor + (nl * _LightColor0 * _LightStrength);
                    }
                    if (depth.w == 2)
                    {
                        color = _testSphereColor + (nl * _LightColor0 * _LightStrength);
                    }
                    if (depth.w == 3)
                    {
                        color = _testSphereColor + (nl * _LightColor0 * _LightStrength);
                    }

                    float3 depthe = depth.xyz * nl * _LightColor0 * _LightStrength;
                    float deep = length(worldPosition - depth.xyz);
                    float fogScale = _scaleSize.x * _fogWeight;
                    float fogColorScale = _scaleSize.x * _fogColorWeight;

                    fixed4 colore = fixed4((color.x / 1 - (deep / fogColorScale)) + ((_fogColor.x) * (deep / fogScale)), (color.y / 1 - (deep / fogColorScale)) + ((_fogColor.y) * (deep / fogScale)), (color.z / 1 - (deep / fogColorScale)) + ((_fogColor.z) * (deep / fogScale)), color.w - (((_fogColor.z) * (deep / fogScale))));
                    //color.w - (((_fogColor.z) * (deep / fogScale)) - .1)
                    return colore;
                }
                else
                {
                    return _fogColor;
                }
            }
            ENDCG
        }
    }
}

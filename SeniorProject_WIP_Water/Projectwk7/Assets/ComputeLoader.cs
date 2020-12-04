using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeLoader : MonoBehaviour
{

    public ComputeShader computeShader;

    public Texture _skyboxTex;

    private RenderTexture _target;

    public Camera _camera;

    private void SetShaderParameters()
    {
        computeShader.SetTexture(0, "_skybox", _skyboxTex);
        computeShader.SetMatrix("_CameraToWorld", _camera.cameraToWorldMatrix);
        computeShader.SetMatrix("_CameraInverseProjection", _camera.projectionMatrix.inverse);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        SetShaderParameters();
        Render(destination);
    }
    private void Render(RenderTexture destination)
    {

        InitRenderTexture();

        computeShader.SetTexture(0, "Result", _target);
        int threadGroupsX = Mathf.CeilToInt(Screen.width / 8.0f);
        int threadGroupsY = Mathf.CeilToInt(Screen.height / 8.0f);
        computeShader.Dispatch(0, threadGroupsX, threadGroupsY, 1);

        Graphics.Blit(_target, destination);
    }
    private void InitRenderTexture()
    {
        if (_target == null || _target.width != Screen.width || _target.height != Screen.height)
        {

            if (_target != null)
                _target.Release();

            _target = new RenderTexture(Screen.width, Screen.height, 0,
                RenderTextureFormat.ARGBFloat, RenderTextureReadWrite.Linear);
            _target.enableRandomWrite = true;
            _target.Create();
        }
    }

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


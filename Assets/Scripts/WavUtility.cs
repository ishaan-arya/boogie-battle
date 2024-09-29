using System;
using UnityEngine;

/// <summary>
/// Utility class for converting PCM byte data to AudioClip.
/// </summary>
public static class WavUtility
{
    /// <summary>
    /// Converts PCM_S16LE byte data to an AudioClip.
    /// </summary>
    /// <param name="data">The PCM byte array.</param>
    /// <param name="offsetSamples">Offset samples if needed.</param>
    /// <param name="name">Name of the AudioClip.</param>
    /// <param name="sampleRate">Sample rate of the audio data.</param>
    /// <returns>An AudioClip object.</returns>
    public static AudioClip ToAudioClip(byte[] data, int offsetSamples, string name, int sampleRate)
    {
        // Ensure the data length is even (16-bit samples)
        if (data.Length % 2 != 0)
        {
            Debug.LogWarning("PCM data length is not even. Ignoring the last byte.");
            Array.Resize(ref data, data.Length - 1);
        }

        int sampleCount = data.Length / 2; // 16 bits = 2 bytes per sample
        float[] samples = new float[sampleCount];

        for (int i = 0; i < sampleCount; i++)
        {
            short sample = BitConverter.ToInt16(data, i * 2);
            samples[i] = sample / 32768f; // Convert to float range [-1, 1]
        }

        // Create AudioClip
        AudioClip audioClip = AudioClip.Create(name, sampleCount, 1, sampleRate, false);
        audioClip.SetData(samples, 0);
        return audioClip;
    }
}

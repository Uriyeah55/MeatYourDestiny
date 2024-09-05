using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// Ubh spiral shot.
/// </summary>
[AddComponentMenu("UniBulletHell/Shot Pattern/Spiral Shot")]
public class UbhSpiralShot : UbhBaseShot
{
    [Header("===== SpiralShot Settings =====")]
    // "Set a starting angle of shot. (0 to 360)"
    [Range(0f, 360f), FormerlySerializedAs("_StartAngle")]
    public float m_startAngle = 180f;
    // "Set a shift angle of spiral. (-360 to 360)"
    [Range(-360f, 360f), FormerlySerializedAs("_ShiftAngle")]
    public float m_shiftAngle = 5f;
    // "Set a delay time between bullet and next bullet. (sec)"
    [FormerlySerializedAs("_BetweenDelay")]
    public float m_betweenDelay = 0.2f;

    private int m_nowIndex;
    private float m_delayTimer;

    public override void Shot()
    {
        if (m_bulletNum <= 0 || m_bulletSpeed <= 0f)
        {
            UbhDebugLog.LogWarning(name + " Cannot shot because BulletNum or BulletSpeed is not set.", this);
            return;
        }

        if (m_shooting)
        {
            return;
        }

        m_shooting = true;
        m_nowIndex = 0;
        m_delayTimer = 0f;
    }

    protected virtual void Update()
    {
        if (m_shooting == false)
        {
            return;
        }

        m_delayTimer -= UbhTimer.instance.deltaTime;

        while (m_delayTimer <= 0)
        {
            UbhBullet bullet = GetBullet(transform.position);
            if (bullet == null)
            {
                FinishedShot();
                return;
            }

            float angle = m_startAngle + (m_shiftAngle * m_nowIndex);

            ShotBullet(bullet, m_bulletSpeed, angle);

            bullet.UpdateMove(-m_delayTimer);

            m_nowIndex++;

            FiredShot();

            if (m_nowIndex >= m_bulletNum)
            {
                FinishedShot();
                return;
            }

            m_delayTimer += m_betweenDelay;
        }
    }
}
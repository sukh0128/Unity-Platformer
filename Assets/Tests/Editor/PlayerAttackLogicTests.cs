using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerAttackLogicTests
{
    [Test]
    public void ShouldAttack_WhenCooldownPassed_ReturnsTrueAndValidFireballIndex()
    {
        // Arrange
        float attackCooldown = 0.5f;
        PlayerAttackLogic playerAttackLogic = new PlayerAttackLogic(attackCooldown);
        playerAttackLogic.Fireballs = new GameObject[2];

        // Make sure one fireball is inactive
        playerAttackLogic.Fireballs[0] = new GameObject();
        playerAttackLogic.Fireballs[0].SetActive(false);
        playerAttackLogic.Fireballs[1] = new GameObject();
        playerAttackLogic.Fireballs[1].SetActive(true);

        // Set process attack to true
        playerAttackLogic.ProcessAttack(true);

        // Act
        int fireballIndex;
        bool shouldAttack = playerAttackLogic.ShouldAttack(out fireballIndex);

        // Assert
        Assert.IsTrue(shouldAttack);
        Assert.AreEqual(0, fireballIndex);
    }

    [Test]
    public void ShouldAttack_WhenAttackNotRequested_ReturnsFalseAndInvalidFireballIndex()
    {
        // Arrange
        var attackCooldown = 1000f;
        PlayerAttackLogic playerAttackLogic = new PlayerAttackLogic(attackCooldown);
        playerAttackLogic.Fireballs = new GameObject[1];

        // Make sure one fireball is inactive
        playerAttackLogic.Fireballs[0] = new GameObject();
        playerAttackLogic.Fireballs[0].SetActive(false);

        // Set process attack to true
        playerAttackLogic.ProcessAttack(false);

        // Act
        int fireballIndex;
        bool shouldAttack = playerAttackLogic.ShouldAttack(out fireballIndex);

        // Assert
        Assert.IsFalse(shouldAttack);
        Assert.AreEqual(-1, fireballIndex);
    }
}

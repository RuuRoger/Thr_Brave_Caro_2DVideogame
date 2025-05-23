using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
#region Events 

    //All events

    public static event Action<Animator> OnGameManagerPlayerMove;
    public static event Action<Animator> OnGameManagerNotPlayerMove;
    public static event Action<SpriteRenderer> OnGameManagerPlayerFlipOn;
    public static event Action<SpriteRenderer> OnGameManagerPlayerFlipOff;
    public static event Action<Animator> OnGameManagerBombAnimation;
    public static event Action OnGameManagerMakeSoundReactiveBomb;
    public static event Action OnGameManagerSoundBombExploted;
    public static event Action OnGameManagerMakeSoundForTheHitWithCamera;
    public static event Action OnGameManagerBombWasExploted;
    public static event Action OnGameManagerKillPlayerByExplotion;
    public static event Action<GameObject, GameObject, SpriteRenderer, Rigidbody2D, BoxCollider2D> OnGameManagerStartRewspawnPlayerLv1;
    public static event Action OnGameManagerStoneMustDestroyed;
    public static event Action OnGameManagerInformThatPlayerGetTheBomb;
    public static event Action OnGameManagerLetOpenWoodDoor;
    public static event Action OnGameManagerPlayerTouchedTheTrigger0;
    public static event Action PlayerTouchedTheTrigger1;
    public static event Action OnStartCinematicLevel2;
    public static event Action OnGameManagerFinishCinematic;
    public static event Action<GameObject, GameObject, SpriteRenderer, Rigidbody2D, BoxCollider2D> OnGameManagerGotoRespawnlv2;
    public static event Action OnGameManagerStopSpikeRcok1;
    public static event Action OnGameManagerStopSpikeRock2;
    public static event Action OnGameManagerStartShowPlatfomr;
    public static event Action GameManagerReactivePillToShowAgainPlatformsLvl3;
    public static event Action<GameObject, GameObject, SpriteRenderer, Rigidbody2D, BoxCollider2D> OnGameManagerPlayerdRespawnlv4;
    public static event Action OnGameManagerActivePill2Lvl4;
    public static event Action OnGameManagerActivePill3lvl4;
    public static event Action OngameManagerActivePill4Lvl4;
    public static event Action OnGameManagerActivePill5Lvl4;
    public static event Action OnGameManagerDestroyColumnsLvl4;
    public static event Action OnGameManagerShowDoor;
    public static event Action OnGameManagerRespawnPillsLvl4;
    public static event Action<GameObject, GameObject, SpriteRenderer, Rigidbody2D, BoxCollider2D> OnGameManagerRespawnPlayerLvl5;
    public static event Action OnGameManagerActiveEventInColliderRespawner;
    public static event Action<SpriteRenderer, float> OnGameManagerStartStealth;
    public static event Action<SpriteRenderer, float> OnGameManagerFinishStealth;
    public static event Action OnGameManagerPlayerInGrass;
    public static event Action OnGameManagerPlayerOutOfGrass;
    public static event Action<GameObject, GameObject, SpriteRenderer, Rigidbody2D, BoxCollider2D> OnGameManagerRespawnPlayerLvl6;


#endregion

#region Handle Methods

    #region From PlayerController

        #region To AnimationCOntroller
            private void HandlePlayerIsMoving(Animator _value) => OnGameManagerPlayerMove?.Invoke(_value);
            private void HandlePlayerIsNotMoving(Animator _value) => OnGameManagerNotPlayerMove?.Invoke(_value);
            private void HandlePlayerUseFlip(SpriteRenderer _value) => OnGameManagerPlayerFlipOn?.Invoke(_value);
            private void HandlePlayerIsNotUsingFlip(SpriteRenderer _value) => OnGameManagerPlayerFlipOff?.Invoke(_value);
        #endregion

    #endregion

    #region From BombToCatch

        #region To ThrowBomb
        private void HandlePlayerCatchedTheBomb() => OnGameManagerInformThatPlayerGetTheBomb?.Invoke();

        #endregion

        #region To AudioController

        private void HandleSoundRespawnBomb() => OnGameManagerMakeSoundReactiveBomb?.Invoke();

        #endregion

    #endregion

    #region FromTrhowBomb

        #region To AnimationController
        private void HandleBombAnimation(Animator _value) => OnGameManagerBombAnimation?.Invoke(_value);
        #endregion
    
        #region To BombToCatch
        private void HandleBombExploted() => OnGameManagerBombWasExploted?.Invoke();
        #endregion

        #region To AudiController
        private void HandleSoundBombExplotion() => OnGameManagerSoundBombExploted?.Invoke();
        #endregion
    #endregion

    #region From BombCollisionDetecion

        #region To Stone

        private void HandleCollisionBombTouchStone() => OnGameManagerStoneMustDestroyed?.Invoke();

        #endregion

        #region To CinematicExplosionToPLayer



        #endregion

    #endregion

    #region From CinematicExplosionToPlayer

        #region To AudicoController

        private void HandleSoundHitWithCamera() => OnGameManagerMakeSoundForTheHitWithCamera?.Invoke();

        #endregion

        #region  To RespawnPlayer

        private void HandleRespawnPlayerForCinematicExplotion(GameObject _value, GameObject _value2, SpriteRenderer _spriterender, Rigidbody2D _rb, BoxCollider2D _collider) => OnGameManagerStartRewspawnPlayerLv1?.Invoke(_value, _value2, _spriterender, _rb, _collider);

        #endregion

    #endregion

    #region From CinematicLvl2

        #region To SpikeRock2

        private void HandleNotifyFinishCinematicLvl2() => OnGameManagerFinishCinematic?.Invoke();

        #endregion

        #region  To StopAndDestroyBridge

        //Make the same notification that do to Spikerock2

        #endregion

    #endregion

    #region From Key

        #region To WoodDoor

        private void LetOpendDoor() => OnGameManagerLetOpenWoodDoor?.Invoke();
        
        #endregion

    #endregion

    #region From SpikesColliders

        #region To RespawnPlayer

        private void GotoRespawnPoint(GameObject _value, GameObject _value2, SpriteRenderer _spriterender, Rigidbody2D _rb, BoxCollider2D _collider) => OnGameManagerGotoRespawnlv2?.Invoke(_value, _value2, _spriterender, _rb, _collider);

        #endregion

        #region To SpikeRock

        private void HandleStopSpikeRock1() => OnGameManagerStopSpikeRcok1?.Invoke();

        #endregion

        #region To SpikeRock2

        private void HandleStopSpikerock2() => OnGameManagerStopSpikeRock2?.Invoke();

        #endregion

    #endregion

    #region From Level2FirstTrigger

        #region To SpikeRock

        private void HandlePlayerTouchTheFirstTriiger() => OnGameManagerPlayerTouchedTheTrigger0?.Invoke();


        #endregion

    #endregion

    #region From Level2SecondTrigger

        #region To SpikeRock2

        private void HandlePlayerTouchedTheSecondTrigger() => PlayerTouchedTheTrigger1?.Invoke();

        #endregion

    #endregion

    #region From StopAndDestroyBridge

        #region To Cinematiclevl2

        private void HandleStartcinematicLevel2()=> OnStartCinematicLevel2?.Invoke();

        #endregion

    #endregion

    #region From StartShowPlatform

        #region ShowPlatformSequences

        private void HandleStartShowhPlatforms() => OnGameManagerStartShowPlatfomr?.Invoke();

        #endregion

    #endregion

    #region From ShowPlatfromsSequences

        #region To StartShowPlatfomr

        private void HandleShowPlatformSequencesReactivePill()=> GameManagerReactivePillToShowAgainPlatformsLvl3?.Invoke();
        
        #endregion

    #endregion

    #region From AuxColldierColumTrick

        #region To RespawnPlayer

        private void HandlePlayerCollisionRespawn(GameObject _vale, GameObject _value2, SpriteRenderer _value3, Rigidbody2D _value4, BoxCollider2D _value5) => OnGameManagerPlayerdRespawnlv4?.Invoke(_vale, _value2, _value3, _value4, _value5);

        #endregion

         #region To "All pills" in level 4

        private void HandleRestartAllpills() => OnGameManagerRespawnPillsLvl4?.Invoke();

         #endregion

    #endregion

    #region From "pills to pills"
        private void HandlePill1DidIt() => OnGameManagerActivePill2Lvl4?.Invoke();
        private void handlePill2DidIt() => OnGameManagerActivePill3lvl4?.Invoke();
        private void HandePill3DidIt() => OngameManagerActivePill4Lvl4?.Invoke();
        private void HandlePill4DidIt() => OnGameManagerActivePill5Lvl4?.Invoke();
    #endregion

    #region From Pill 5

        #region To ColumnTrick

        private void HandelPillDestroyColumns() => OnGameManagerDestroyColumnsLvl4?.Invoke();

        #endregion

        #region To ShowDoorlvl4

        private void HandleShowDoor() => OnGameManagerShowDoor.Invoke();

        #endregion

    #endregion
    
    #region From ColliderRespawner

        #region To RespawnPlayer

        private void HandleRespawnLevel5(GameObject _value, GameObject _value2, SpriteRenderer _spriterender, Rigidbody2D _rb, BoxCollider2D _collider) => OnGameManagerRespawnPlayerLvl5?.Invoke(_value, _value2, _spriterender, _rb, _collider);

        #endregion

    #endregion

    #region From Bullet

        #region To ColliderRespawner

        private void HandleActiveEventInColliderRespawner() => OnGameManagerActiveEventInColliderRespawner?.Invoke();


        #endregion

    #endregion

    #region From Grass

        #region To AnimationController

            private void HandleStealthModeStart(SpriteRenderer _value, float _value2) => OnGameManagerStartStealth?.Invoke(_value, _value2);
            private void HandleStealthModeFinish(SpriteRenderer _value, float _value2) => OnGameManagerFinishStealth?.Invoke(_value, _value2);

        #endregion

        #region To CameraVision

        private void HandlePlayerInGrass() => OnGameManagerPlayerInGrass?.Invoke();
        private void HandlePlayerOutOfGrass() => OnGameManagerPlayerOutOfGrass?.Invoke();

        #endregion

    #endregion

    #region From CameraVision

        #region To PlayerRespawner

        private void HandleRespawnLevl6(GameObject _value, GameObject _value2, SpriteRenderer _spriterender, Rigidbody2D _rb, BoxCollider2D _collider) => OnGameManagerRespawnPlayerLvl6?.Invoke(_value, _value2, _spriterender, _rb, _collider);

        #endregion

    #endregion

 #endregion

#region Unity CallBacks

    private void OnEnable()
    {
        //Cinematic Lvl2

        #region From PlayerController

            #region To AnimationController
                PlayerController.OnPlayerControllerMovement += HandlePlayerIsMoving; //Notify Player is moving
                PlayerController.OnPlayerControllerNotMovement += HandlePlayerIsNotMoving; //Notify _player is stop
                PlayerController.OnPlayerControllerFlipOn += HandlePlayerUseFlip;  //Nottfy _player use flip
                PlayerController.OnPLayerControllerFlipOff += HandlePlayerIsNotUsingFlip; //Notify _player is not use flip
            #endregion

        #endregion

        #region From BombToCatch 

            #region To ThrowBomb
                BombToCatch.OnPlayerCatchTheBomb += HandlePlayerCatchedTheBomb; //Notify that player catch the bomb
            #endregion

            #region To AudioController
                BombToCatch.OnPlayerSoundReactiveBomb += HandleSoundRespawnBomb; //Notify to make the sound when bomb
        #endregion

        #endregion

        #region From TrhowBomb

            #region To AnimationController
                TrhowBomb.OnThrowBombAnimation += HandleBombAnimation;
            #endregion

            #region To BombToCatch
                TrhowBomb.OnThrowBombBombExploted += HandleBombExploted;
            #endregion

            #region To AudioController
                TrhowBomb.OnThrowBombSoundBombSequence += HandleSoundBombExplotion;
            #endregion

        #endregion

        #region From BombCollisionDetection

            #region To Stone

            BombCollisionDetection.OnBombCollisionStoneWasTouchedByTheBomb += HandleCollisionBombTouchStone;

            #endregion

            #region To CinematicExplosionToPLayer

            BombCollisionDetection.OnKillPlayerWithExplotion += () => OnGameManagerKillPlayerByExplotion?.Invoke();

            #endregion

        #endregion

        #region From CinematicExplotionToPlayer

            #region To AudioController

            CinematicExplosionToPlayer.OnCinematicExplotionMakeHitSoundPlayer += HandleSoundHitWithCamera;

            #endregion

            #region To RespawnPlayer

            CinematicExplosionToPlayer.OnCinematicCallRespawnPlayerLevel += HandleRespawnPlayerForCinematicExplotion;

            #endregion

        #endregion

        #region From CinematicLvl2

            #region To SpikeRock2 

            CinematicLvl2.OnFinishCinematic += HandleNotifyFinishCinematicLvl2;

            #endregion

            #region To StopAndDestroyBridge

            CinematicLvl2.OnFinishCinematic += HandleNotifyFinishCinematicLvl2;

            #endregion

        #endregion

        #region From Key

            #region To WoodDoor

            Key.OnKeyCatched += LetOpendDoor;

            #endregion

        #endregion

        #region From SpikesCollider

            #region To RespawnPlayer

            SpikesCollider.GotoRespawnPoint += GotoRespawnPoint;

            #endregion

            #region To SpikeRock

            SpikesCollider.OnStopSpikeRcok1 += HandleStopSpikeRock1;

            #endregion

            #region To SpikeRock2

            SpikesCollider.OnStopSpikeRcok2 += HandleStopSpikerock2;

            #endregion

        #endregion

        #region Triggers lv2

            #region From Level2FirstTrigger

                #region To SpikeRock

                Level2FirstTrigger.ActiveSpikeRock += HandlePlayerTouchTheFirstTriiger;
                #endregion

            #endregion

            #region From Level2SecondTrigger

                #region To SpikeRock2

                Level2SecondTrigger.ActiveSpikeRock2 += HandlePlayerTouchedTheSecondTrigger;

                #endregion

            #endregion

        #endregion

        #region From StopAndDestroyBridge

            #region To Cinematiclevl2

            StopAndDestroyBridge.ONStartCinematic += HandleStartcinematicLevel2;

            #endregion

        #endregion

        #region From StartShowPlatform

            #region ShowPlatformSequences

            StartShowPlatforms.OnStartShowPlatformTouchPill += HandleStartShowhPlatforms;

            #endregion

        #endregion

        #region From ShowPlatformsSequences

            #region StartShowPlatform

            ShowPlatformsSequences.OnShowPlatformSequencesReactivePill += HandleShowPlatformSequencesReactivePill;

            #endregion

        #endregion

        #region From AuxColliderCOlumTrick

            #region To RespawnPlayer

            AuxColliderColumTrick.PlayerCollisionRespawn += HandlePlayerCollisionRespawn;

            #endregion

            #region To "All pills" in level 4

            AuxColliderColumTrick.OnAuxCollTrickRestartPillsLvl4 += HandleRestartAllpills;

            #endregion

        #endregion

        #region Pills

        #region From PillLvl4

            #region To Pill2Lvl4
            PillLvl4.OnPill1DidIt += HandlePill1DidIt;
            #endregion

        #endregion

        #region From Pill2Lvl4

            #region To Pill3Lvl4
            Pill2Lv4.Onpill2DidIt += handlePill2DidIt;
            #endregion

        #endregion

        #region From Pill3Lvl4

            #region To Pill4Lvl4
            Pill3Lvl4.OnPill3DidIt += HandePill3DidIt;
            #endregion

        #endregion

        #region From Pill4Lvl4

            #region To Pill5Lvl4;
            Pill4Lvl4.OnPill4DidIt += HandlePill4DidIt;
            #endregion

        #endregion

        #region From Pill5Lvl4

            #region To ColumTrick

            Pill5Lvl4.OnPill5DestroyColums += HandelPillDestroyColumns;

            #endregion

            #region To ShowDoorLvl4

            Pill5Lvl4.OnPill5ShowDoorFinalLevel += HandleShowDoor;

            #endregion

        #endregion

        #endregion

        #region From ColliderRespawner

            #region To RespawnPlayer

            ColliderRespawner.OnColliderRespawnerRespawnPlayer += HandleRespawnLevel5;

            #endregion

        #endregion

        #region From Bullet

            #region To ColliderRespawner

            Bullet.OnBulletTouchedPlayer += HandleActiveEventInColliderRespawner;
            #endregion

        #endregion

        #region From Grass

            #region To AnimationController

            Grass.OnGrassStealthStart += HandleStealthModeStart;
            Grass.OnGrassStealthFinish += HandleStealthModeFinish;

            #endregion

            #region To CameraVision

            Grass.OnGrassIsInGrass += HandlePlayerInGrass;
            Grass.OnGrassOutOfGrass += HandlePlayerOutOfGrass;

            #endregion

        #endregion

        #region From CameraVision

            #region To RespawnPlayer

            CameraVision.OnCameraVisionRespawnPlayerLv6 += HandleRespawnLevl6;

            #endregion

        #endregion

    }
    private void OnDisable()
    {
        #region From PlayerController

            #region To AnimationController

            PlayerController.OnPlayerControllerMovement -= HandlePlayerIsMoving;
            PlayerController.OnPlayerControllerNotMovement -= HandlePlayerIsNotMoving;
            PlayerController.OnPlayerControllerFlipOn -= HandlePlayerUseFlip;
            PlayerController.OnPLayerControllerFlipOff -= HandlePlayerIsNotUsingFlip;

            #endregion

        #endregion

        #region From BomToCatch

            #region To ThrowBomb

            BombToCatch.OnPlayerCatchTheBomb -= HandlePlayerCatchedTheBomb;

            #endregion

            #region To AudioController

            BombToCatch.OnPlayerSoundReactiveBomb -= HandleSoundRespawnBomb;

            #endregion

        #endregion

        #region From TrhowBombs

            #region To AnimationController

            TrhowBomb.OnThrowBombAnimation -= HandleBombAnimation;

            #endregion

            #region To BombToCatch

            TrhowBomb.OnThrowBombBombExploted -= HandleBombExploted;

            #endregion

            #region To AudioController
                TrhowBomb.OnThrowBombSoundBombSequence -= HandleSoundBombExplotion;
            #endregion

        #endregion

        #region From BombCollisionDetection

            #region To Stone

            BombCollisionDetection.OnBombCollisionStoneWasTouchedByTheBomb -= HandleCollisionBombTouchStone;

            #endregion

        #endregion

        #region From CinematicExplosionToPlayer

            #region To AudioController

            CinematicExplosionToPlayer.OnCinematicExplotionMakeHitSoundPlayer -= HandleSoundHitWithCamera;

            #endregion

            #region To RespawnPlayer

            CinematicExplosionToPlayer.OnCinematicCallRespawnPlayerLevel -= HandleRespawnPlayerForCinematicExplotion;

            #endregion

        #endregion
    
        #region From CinematicLvl2

            #region To SpikeRock2 

            CinematicLvl2.OnFinishCinematic -= HandleNotifyFinishCinematicLvl2;

            #endregion

            #region To StopAndDestroyBridge

            CinematicLvl2.OnFinishCinematic -= HandleNotifyFinishCinematicLvl2;

            #endregion

        #endregion

        #region From Key

            #region To WoodDoor

            Key.OnKeyCatched -= LetOpendDoor;

            #endregion

        #endregion
    
        #region From SpikesCollider

            #region To RespawnPlayer

            SpikesCollider.GotoRespawnPoint -= GotoRespawnPoint;

            #endregion

            #region To SpikeRock

            SpikesCollider.OnStopSpikeRcok1 -= HandleStopSpikeRock1;

            #endregion

            #region To SpikeRock2

            SpikesCollider.OnStopSpikeRcok2 -= HandleStopSpikerock2;

            #endregion

        #endregion
    
        #region Triggers lv2

            #region From Level2FirstTrigger

                #region To SpikeRock

                Level2FirstTrigger.ActiveSpikeRock -= HandlePlayerTouchTheFirstTriiger;
                #endregion

            #endregion

            #region From Level2SecondTrigger

                #region To SpikeRock2

                Level2SecondTrigger.ActiveSpikeRock2 -= HandlePlayerTouchedTheSecondTrigger;

                #endregion

            #endregion

        #endregion
    
        #region From StopAndDestroyBridge

            #region To Cinematiclevl2

            StopAndDestroyBridge.ONStartCinematic -= HandleStartcinematicLevel2;

            #endregion

        #endregion
    
        #region From StartShowPlatform

            #region ShowPlatformSequences

            StartShowPlatforms.OnStartShowPlatformTouchPill -= HandleStartShowhPlatforms;

            #endregion

        #endregion

        #region From ShowPlatformsSequences

            #region StartShowPlatform

            ShowPlatformsSequences.OnShowPlatformSequencesReactivePill -= HandleShowPlatformSequencesReactivePill;

            #endregion

        #endregion

        #region From AuxColliderCOlumTrick

            #region To RespawnPlayer

            AuxColliderColumTrick.PlayerCollisionRespawn -= HandlePlayerCollisionRespawn;

            #endregion

            #region To "All pills" in level 4

            AuxColliderColumTrick.OnAuxCollTrickRestartPillsLvl4 -= HandleRestartAllpills;

            #endregion

        #endregion

        #region Pills

        #region From PillLvl4

            #region To Pill2Lvl4
            PillLvl4.OnPill1DidIt -= HandlePill1DidIt;
            #endregion

        #endregion

        #region From Pill2Lvl4

            #region To Pill3Lvl4
            Pill2Lv4.Onpill2DidIt -= handlePill2DidIt;
            #endregion

        #endregion

        #region From Pill3Lvl4

            #region To Pill4Lvl4
            Pill3Lvl4.OnPill3DidIt -= HandePill3DidIt;
            #endregion

        #endregion

        #region From Pill4Lvl4

            #region To Pill5Lvl4;
            Pill4Lvl4.OnPill4DidIt -= HandlePill4DidIt;
            #endregion

        #endregion

        #region From Pill5Lvl4

            #region To ColumTrick

            Pill5Lvl4.OnPill5DestroyColums -= HandelPillDestroyColumns;

            #endregion

            #region To ShowDoorLvl4

            Pill5Lvl4.OnPill5ShowDoorFinalLevel -= HandleShowDoor;

            #endregion

        #endregion

        #endregion

        #region From ColliderRespawner

            #region To RespawnPlayer

            ColliderRespawner.OnColliderRespawnerRespawnPlayer -= HandleRespawnLevel5;

            #endregion

        #endregion

        #region From Bullet

            #region To ColliderRespawner

            Bullet.OnBulletTouchedPlayer -= HandleActiveEventInColliderRespawner;
            #endregion

        #endregion

        #region From Grass

            #region To AnimationController

            Grass.OnGrassStealthStart -= HandleStealthModeStart;
            Grass.OnGrassStealthFinish -= HandleStealthModeFinish;

            #endregion

            #region To CameraVision

            Grass.OnGrassIsInGrass -= HandlePlayerInGrass;
            Grass.OnGrassOutOfGrass -= HandlePlayerOutOfGrass;

            #endregion

        #endregion

        #region From CameraVision

            #region To RespawnPlayer

            CameraVision.OnCameraVisionRespawnPlayerLv6 -= HandleRespawnLevl6;

            #endregion

        #endregion

    }

#endregion

}

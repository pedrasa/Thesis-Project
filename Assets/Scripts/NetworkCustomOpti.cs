using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using Didimo.Core.Deformables;
using Didimo.Core.Inspector;
using Didimo.Core.Utility;
using Didimo.Extensions;
using Unity.Mathematics;

namespace Didimo.Networking
{
    public class NetworkCustomOpti : MonoBehaviour, ListToPopupAttribute.IListToPopup
    {
        [SerializeField, Readonly]
        protected string didimoKey;

        [SerializeField, Readonly]
        protected DidimoComponents didimoComponents;

        private List<string> didimoList;

        /*public int NumberofImports, Bald1, Bald2, Bald3;
        public GameObject Player;
        public GameObject Button, Button1, Text;
        public GameObject avatar1;
        public GameObject avatar2;
        public GameObject avatar3;
        public GameObject Rootnode1;
        public GameObject Rootnode2;
        public GameObject Rootnode3;
        private GameObject child;
        public List<GameObject> children1;
        public List<GameObject> children2;
        public List<GameObject> children3;
        public RuntimeAnimatorController newController1;
        public RuntimeAnimatorController newController2;
        public RuntimeAnimatorController newController3;
        public Avatar newAvatar1;
        public Avatar newAvatar2;
        public Avatar newAvatar3;
        public GameObject Empty, Teleport;*/

        public int Bald1;
        public GameObject Player, Copy;
        public GameObject Text;
        public GameObject avatar1, avatar2;
        public GameObject Rootnode1, Rootnode2;
        private GameObject child;
        public List<GameObject> children1, children2;
        public RuntimeAnimatorController newController1, newController2;
        public Avatar newAvatar1, newAvatar2;
        public GameObject Empty, Teleport;
        public List<string> DidimoKeys;
        public NetworkConfig NetConfig;

        //idea for chaning Network Config -> DidimoNetworkReosurces now uses this Net Config, check if it works then check if the changes work (Works -Provisionary-)
        // Whenever you need the custom API you gotta use Didimo.Networking.API.SetImplementation(new CustomAPI());

        //Uncomment if you want to be able

        [ListToPopup]
        public int selectedDidimo;

        public List<string> ListToPopupGetValues() => didimoList;
        public void ListToPopupSetSelectedValue(int i) { selectedDidimo = i; }
        public string ProgressMessage { get; private set; }
        public float Progress { get; private set; }

        void Start()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
        }
        private void OnValidate()
        {
            ProgressMessage = null;
            Progress = 0f;
        }

        /*public void DidimoKeyList(string x, string y, string z)
        {
            DidimoKeys.Add(x);
            DidimoKeys.Add(y);
            DidimoKeys.Add(z);
        }*/

        public void DidimoKeyList(string x)
        {
            DidimoKeys.Add(x);
        }
        public void DidimoButton(int x)
        {
            ImportFromKeyCustom(DidimoKeys[x]);
        }

        public void APIKeySet(string x)
        {
            NetConfig.ApiKey = x;
        }

        public async Task ImportFromKeyCustom(string CustomKey)
        {
            Api.SetImplementation(new CustomAPI());
            string chosenKey = CustomKey;

            if (string.IsNullOrEmpty(chosenKey)) return;

            ProgressMessage = "Importing your didimo";
            Progress = 0f;
            Task<(bool success, DidimoComponents didimo)> importFromKeyTask = Api.Instance.DidimoFromKey(chosenKey, null, progress => { Progress = progress; });
            await importFromKeyTask;
            ProgressMessage = null;

            didimoKey = importFromKeyTask.Result.didimo.DidimoKey;
            didimoComponents = importFromKeyTask.Result.didimo;

            /*NumberofImports += 1;
            if (NumberofImports == 1)
            {
                Button.SetActive(true);
            }
            if (NumberofImports == 2)
            {
                Button1.SetActive(true);
            }
            if (NumberofImports >= 3)
            {
                Text.SetActive(true);
                ChangeRootNode();
            }*/

            //Text.SetActive(true);
            ChangeRootNode();
        }

        [Button]
        public void ChangeRootNode()
        {
            //int x = 1;
            foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                if (gameObj.name == "RootNode")
                {
                    /*if (x == 1)
                    {
                        Rootnode1 = gameObj;
                        (Instantiate(Empty, new Vector3(1, 1, 1), new Quaternion(1, 1, 1, 1))).transform.parent = Rootnode1.transform.GetChild(0).gameObject.transform;
                        Player.GetComponent<TalkinAnim>().SetDidimo(Rootnode1);
                    }
                    else if (x == 2)
                    {
                        Rootnode2 = gameObj;
                        (Instantiate(Empty, new Vector3(1, 1, 1), new Quaternion(1, 1, 1, 1))).transform.parent = Rootnode2.transform.GetChild(0).gameObject.transform;
                    }
                    else
                    {
                        Rootnode3 = gameObj;
                        (Instantiate(Empty, new Vector3(1, 1, 1), new Quaternion(1, 1, 1, 1))).transform.parent = Rootnode3.transform.GetChild(0).gameObject.transform;
                    }
                    x += 1;*/
                    Rootnode1 = gameObj;
                    Copy = Instantiate(gameObj.transform.parent.gameObject);
                    Rootnode2 = Copy.transform.GetChild(0).gameObject;
                    (Instantiate(Empty, new Vector3(1, 1, 1), new Quaternion(1, 1, 1, 1))).transform.parent = Rootnode1.transform.GetChild(0).gameObject.transform;
                    (Instantiate(Empty, new Vector3(1, 1, 1), new Quaternion(1, 1, 1, 1))).transform.parent = Rootnode2.transform.GetChild(0).gameObject.transform;
                    Player.GetComponent<TalkinAnim>().SetDidimo(Rootnode2);
                }
            }
            //Teleport.GetComponent<TeleportOpti>().AssignAvatars(Rootnode1, Rootnode2, Rootnode3);
            Teleport.GetComponent<TeleportOpti>().AssignAvatars(Rootnode1, Rootnode2);
            Player.GetComponent<PlayerMovementOpti>().startTeleport();

        }

        [Button]
        public void GetChildren()
        {
            Rootnode1.AddComponent<Animator>().avatar = newAvatar1;
            Rootnode1.GetComponent<Animator>().runtimeAnimatorController = newController1;
            child = Rootnode1.transform.GetChild(0).gameObject;
            int y = 0;
            while (y != 9)
            {
                children1.Add(child.transform.GetChild(y).gameObject);
                y++;
            }
            Rootnode2.AddComponent<Animator>().avatar = newAvatar2;
            Rootnode2.GetComponent<Animator>().runtimeAnimatorController = newController2;
            child = Rootnode2.transform.GetChild(0).gameObject;
            y = 0;
            while (y != 9)
            {
                children2.Add(child.transform.GetChild(y).gameObject);
                y++;
            }
            /*Rootnode3.AddComponent<Animator>().avatar = newAvatar3;
            Rootnode3.GetComponent<Animator>().runtimeAnimatorController = newController3;
            child = Rootnode3.transform.GetChild(0).gameObject;
            y = 0;
            while (y != 9)
            {
                children3.Add(child.transform.GetChild(y).gameObject);
                y++;
            }*/
            ChangeAvatars();
        }

        [Button]
        public void ChangeAvatars()
        {
            /*child = avatar1.transform.GetChild(0).gameObject;
            int y = 0;
            while (y != 9)
            {
                child.transform.GetChild(y).gameObject.SetActive(false);
                children1[y].transform.SetPositionAndRotation(child.transform.GetChild(y).gameObject.transform.position, child.transform.GetChild(y).gameObject.transform.rotation);
                children1[y].transform.SetParent(child.transform);
                if (y != 0)
                {
                    if (children1[y].name == "Empty(Clone)")
                    {
                        children1[y].AddComponent<SkinnedMeshRenderer>().rootBone = avatar1.transform;
                        Bald1 = 1;
                    }
                    else
                    {
                        children1[y].GetComponent<SkinnedMeshRenderer>().rootBone = avatar1.transform;
                    }
                }
                else
                {
                    children1[y].GetComponent<Transform>().localScale = child.transform.localScale;
                }
                y++;
            }
            child = avatar2.transform.GetChild(0).gameObject;
            y = 0;
            while (y != 9)
            {
                child.transform.GetChild(y).gameObject.SetActive(false);
                children2[y].transform.SetPositionAndRotation(child.transform.GetChild(y).gameObject.transform.position, child.transform.GetChild(y).gameObject.transform.rotation);
                children2[y].transform.SetParent(child.transform);
                if (y != 0)
                {
                    if (children2[y].name == "Empty(Clone)")
                    {
                        children2[y].AddComponent<SkinnedMeshRenderer>().rootBone = avatar2.transform;
                        Bald2 = 1;
                    }
                    else
                    {
                        children2[y].GetComponent<SkinnedMeshRenderer>().rootBone = avatar2.transform;
                    }
                }
                else
                {
                    children2[y].GetComponent<Transform>().localScale = child.transform.localScale;
                }
                y++;
            }
            child = avatar3.transform.GetChild(0).gameObject;
            y = 0;
            while (y != 9)
            {
                child.transform.GetChild(y).gameObject.SetActive(false);
                children3[y].transform.SetPositionAndRotation(child.transform.GetChild(y).gameObject.transform.position, child.transform.GetChild(y).gameObject.transform.rotation);
                children3[y].transform.SetParent(child.transform);
                if (y != 0)
                {
                    if (children3[y].name == "Empty(Clone)")
                    {
                        children3[y].AddComponent<SkinnedMeshRenderer>().rootBone = avatar3.transform;
                        Bald3 = 1;
                    }
                    else
                    {
                        children3[y].GetComponent<SkinnedMeshRenderer>().rootBone = avatar3.transform;
                    }
                }
                else
                {
                    children3[y].GetComponent<Transform>().localScale = child.transform.localScale;
                }
                y++;
            }
            Player.GetComponent<PlayerMovementOpti>().ChangeOpti();
            */
            child = avatar1.transform.GetChild(0).gameObject;
            int y = 0;
            while (y != 9)
            {
                child.transform.GetChild(y).gameObject.SetActive(false);
                children1[y].transform.SetPositionAndRotation(child.transform.GetChild(y).gameObject.transform.position, child.transform.GetChild(y).gameObject.transform.rotation);
                children1[y].transform.SetParent(child.transform);
                if (y != 0)
                {
                    if (children1[y].name == "Empty(Clone)")
                    {
                        children1[y].AddComponent<SkinnedMeshRenderer>().rootBone = avatar1.transform;
                        Bald1 = 1;
                    }
                    else
                    {
                        children1[y].GetComponent<SkinnedMeshRenderer>().rootBone = avatar1.transform;
                    }
                }
                else
                {
                    children1[y].GetComponent<Transform>().localScale = child.transform.localScale;
                }
                children1[y].layer = 3;
                y++;
            }
            child = avatar2.transform.GetChild(0).gameObject;
            y = 0;
            while (y != 9)
            {
                child.transform.GetChild(y).gameObject.SetActive(false);
                children2[y].transform.SetPositionAndRotation(child.transform.GetChild(y).gameObject.transform.position, child.transform.GetChild(y).gameObject.transform.rotation);
                children2[y].transform.SetParent(child.transform);
                if (y != 0)
                {
                    if (children2[y].name == "Empty(Clone)")
                    {
                        children2[y].AddComponent<SkinnedMeshRenderer>().rootBone = avatar2.transform;
                    }
                    else
                    {
                        children2[y].GetComponent<SkinnedMeshRenderer>().rootBone = avatar2.transform;
                    }
                }
                else
                {
                    children2[y].GetComponent<Transform>().localScale = child.transform.localScale;
                }
                children2[y].layer = 7;
                y++;
            }
            Player.GetComponent<PlayerMovementOpti>().ChangeOpti();
        }

#if UNITY_EDITOR

        [Button]
        void OpenDeveloperPortalDocumentation() { Application.OpenURL(UsefulLinks.CREATING_A_DIDIMO_DEVELOPER_PORTAL); }

        [Button("Create didimo And Import")]
        public async Task CreateDidimoAndImport()
        {
            if (ProgressMessage != null)
            {
                EditorUtility.DisplayDialog("Error", "Please wait for the current request to complete.", "OK");
                return;
            }

            if (!Application.isPlaying)
            {
                EditorUtility.DisplayDialog("Error", "To use this feature you must first enter play mode", "OK");
                return;
            }

            string photoFilePath = EditorUtility.OpenFilePanel("Choose a photo", "", "png,jpg");
            if (string.IsNullOrEmpty(photoFilePath)) return;
            ProgressMessage = "Creating your didimo";
            Progress = 0f;
            Debug.Log("Creating didimo");
            Task<(bool success, DidimoComponents didimo)> createDidimoTask = Api.Instance.CreateDidimoAndImportGltf(photoFilePath,
                null,
                progress =>
                {
                    Progress = progress;
                });
            await createDidimoTask;
            ProgressMessage = null;

            if (!createDidimoTask.Result.success)
            {
                EditorUtility.DisplayDialog("Failed to create didimo", "Failed to create your didimo. Please check the console for logs.", "OK");
                return;
            }

            EditorUtility.DisplayDialog("Created didimo", "Created and imported your didimo with success. You can inspect it in the scene.", "OK");
            didimoKey = createDidimoTask.Result.didimo.DidimoKey;
            didimoComponents = createDidimoTask.Result.didimo;
        }

        [Button("Delete didimo")]
        public async Task DeleteDidimo()
        {
            Task<bool> deleteTask = Api.Instance.DeleteDidimo(didimoKey);
            await deleteTask;
            if (deleteTask.Result)
            {
                EditorUtility.DisplayDialog("Deleted didimo", $"Deleted didimo with key: {didimoKey}", "OK");
            }
            else
            {
                EditorUtility.DisplayDialog("Failed to delete didimo", $"Failed to delete didimo with key {didimoKey}", "OK");
            }
        }

        [Button("List didimos")]
        public async Task ListDidimos()
        {
            didimoList = new List<string>();
            Task<(bool success, List<DidimoDetailsResponse> didimos)> listTask = Api.Instance.GetAllDidimos();
            await listTask;
            if (!listTask.Result.success) return;

            didimoList.AddRange(listTask.Result.didimos.Select(item => item.DidimoKey));
        }

        [Button]
        public async Task ImportFromKey()
        {
            Api.SetImplementation(new CustomAPI());
            if (ProgressMessage != null)
            {
                EditorUtility.DisplayDialog("Error", "Please wait for the current request to complete.", "OK");
                return;

            }

            if (!Application.isPlaying)
            {
                EditorUtility.DisplayDialog("Error", "To use this feature you must first enter play mode", "OK");
                return;
            }

            string chosenKey = didimoList[selectedDidimo];

            if (string.IsNullOrEmpty(chosenKey)) return;

            ProgressMessage = "Importing your didimo";
            Progress = 0f;
            Task<(bool success, DidimoComponents didimo)> importFromKeyTask = Api.Instance.DidimoFromKey(chosenKey, null, progress => { Progress = progress; });
            await importFromKeyTask;
            ProgressMessage = null;

            if (!importFromKeyTask.Result.success)
            {
                EditorUtility.DisplayDialog("Failed to import didimo", "Failed to import your didimo. Please check the console for logs.", "OK");
                return;
            }

            EditorUtility.DisplayDialog("Imported didimo", "Imported your didimo with success. You can inspect it in the scene.", "OK");
            didimoKey = importFromKeyTask.Result.didimo.DidimoKey;
            didimoComponents = importFromKeyTask.Result.didimo;
            
        }


        [Button]
        protected async Task AddRandomHair()
        {
            if (ProgressMessage != null)
            {
                EditorUtility.DisplayDialog("Error", "Please wait for the current request to complete.", "OK");
                return;

            }

            if (!Application.isPlaying)
            {
                EditorUtility.DisplayDialog("Error", "To use this feature you must first enter play mode", "OK");
                return;
            }

            if (didimoComponents == null)
            {
                EditorUtility.DisplayDialog("Error", "First, create a didimo", "OK");
                return;
            }

            var deformableDatabase = UnityEngine.Resources.Load<DeformableDatabase>("DeformableDatabase");
            string deformableId = deformableDatabase.AllIDs.RandomOrDefault();
            if (!didimoComponents.Deformables.TryCreate(deformableId, out Deformable deformable))
            {
                EditorUtility.DisplayDialog("Error", "Failed to create deformable", "OK");
                return;
            }

            deformable.gameObject.SetActive(false);
            byte[] undeformedMeshData = deformable.GetUndeformedMeshData();
            Progress = 0.0f;
            ProgressMessage = "Deforming asset";
            (bool success, byte[] deformedMeshData) = await Api.Instance.Deform(didimoComponents.DidimoKey, undeformedMeshData, progress => { Progress = progress; });
            if (!success)
            {
                EditorUtility.DisplayDialog("Error", "Error with api call", "OK");
                ProgressMessage = null;
                return;
            }
            ProgressMessage = null;

            deformable.SetDeformedMeshData(deformedMeshData);
            deformable.gameObject.SetActive(true);
        }

        [Button]
        private void ChangeHairColor()
        {
            if (didimoComponents == null)
            {
                EditorUtility.DisplayDialog("Error", "First, create a didimo", "OK");
                return;
            }

            if (didimoComponents.Deformables.TryFind(out Hair hair))
            {
                Selection.objects = new Object[] { hair };
                // You can also set a preset with:
                // hair.SetPreset(0);
            }
            else
            {
                EditorUtility.DisplayDialog("Error", "Please add a hairstyle to your didimo first", "OK");
            }
        }

        [Button]
        private void RemoveHair()
        {
            if (didimoComponents.Deformables.TryFind(out Hair hair))
            {
                if (Application.isPlaying) Destroy(hair.gameObject);
                else DestroyImmediate(hair.gameObject);
            }
            else
            {
                Debug.Log("Could not find hair to remove.");
            }
        }
#endif
    }
}

using OutSystems.ExternalLibraries.SDK;

namespace PH.Structures
{

    [OSStructure(Description = "Auth info")]
    public struct Authenticationinfo
    {
        [OSStructureField(DataType = OSDataType.Text, Description = "AWS Region", IsMandatory = true)]
        public string AwsRegion;
        [OSStructureField(DataType = OSDataType.Text, Description = "AWS Access Key ID", IsMandatory = true)]
        public string AwsAccessKeyId;
        [OSStructureField(DataType = OSDataType.Text, Description = "AWS Secret Access Key", IsMandatory = true)]
        public string awsSecretAccessKey;
    }

    [OSStructure(Description = "Structure containing details about the detected label, including name, and level of confidence.")]
    [Serializable()]
    public struct Label
    {

        [OSStructureField(DataType = OSDataType.Text, Description = "The name (label) of the object.", IsMandatory = true)]
        public string Name;
        [OSStructureField(DataType = OSDataType.Decimal, Description = "Level of confidence.", IsMandatory = true)]
        public float Confidence;
    }

    [OSStructure(Description = "Bounding box of the face.")]
    public struct BoundingBox
    {
        public float Height;
        public float Left;
        public float Top;
        public float Width;
    }

    [OSStructure(Description = "Type2")]
    public struct Type2
    {
        public string Value;
    }

    [OSStructure(Description = "LandmarkItem")]
    public struct LandmarkItem
    {
        public Type2 Type;
        public float X;
        public float Y;
    }

    [OSStructure(Description = "Pose")]
    public struct Pose
    {
        public float Pitch;
        public float Roll;
        public float Yaw;
    }

    [OSStructure(Description = "Quality")]
    public struct Quality
    {
        public float Brightness;
        public float Sharpness;
    }

    [OSStructure(Description = "AgeRange")]
    public struct AgeRange
    {
        public long High;
        public long Low;
    }

    [OSStructure(Description = "Beard")]
    public struct Beard
    {
        public float Confidence;
        public bool Value;
    }

    [OSStructure(Description = "EmotionItem")]
    public struct EmotionItem
    {
        public float Confidence;
        public Type2 Type;
    }

    [OSStructure(Description = "Gender")]
    public struct Gender
    {
        public float Confidence;
        public Type2 Value;
    }
    [OSStructure(Description = "FaceDetailItem")]
    public struct FaceDetailItem
    {
        public AgeRange AgeRange;
        public Beard Beard;
        public BoundingBox BoundingBox;
        public float Confidence;
        public IEnumerable<EmotionItem> Emotions;
        public Beard Eyeglasses;
        public Beard EyesOpen;
        public Gender Gender;

        public IEnumerable<LandmarkItem> Landmarks;
        public Beard MouthOpen;
        public Beard Mustache;
        public Pose Pose;
        public Quality Quality;
        public Beard Smile;
        public Beard Sunglasses;

    }

    [OSStructure(Description = "ResponseMetadata")]
    public struct ResponseMetadata
    {
        public string RequestId;
    }

    [OSStructure(Description = "Provides face metadata (bounding box and confidence that the bounding box actually contains a face).")]
    public struct Face
    {
        public BoundingBox boundingBox;
        public float confidence;
        public IEnumerable<LandmarkItem> landmarkItems;
        public Quality quality;
        public Pose pose;
    }

    [OSStructure(Description = "Face in the target image that match the source image face. Each CompareFacesMatch object provides the bounding box, the confidence level that the bounding box contains a face, and the similarity score for the face in the bounding box and the face in the source image.")]
    public struct FaceMatch
    {
        public double similarity;
        public Face face;

    }

    [OSStructure(Description = "The equivalent to CompareFacesResponse Amazon structure, but with less fields.")]
    public struct CompareFaces
    {
        public long HttpStatusCode;
        public IEnumerable<FaceMatch> facematches;
    }

    [OSStructure(Description = "Provides information about a single type of inappropriate, unwanted, or offensive content found in an image.")]
    public struct ModerationLabel
    {
        [OSStructureField(DataType = OSDataType.Text, Description = "The label name for the type of unsafe content detected in the image.")]
        public string Name;
        [OSStructureField(DataType = OSDataType.Decimal, Description = "Specifies the confidence that Amazon Rekognition has that the label has been correctly identified.")]
        public float Confidence;
        [OSStructureField(DataType = OSDataType.Text, Description = "The name for the parent label.")]
        public string ParentName;
    }

}
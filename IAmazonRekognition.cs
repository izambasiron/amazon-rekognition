using OutSystems.ExternalLibraries.SDK;
using PH.Structures;

namespace PH
{
    /// <summary>
    /// The IAmazonRekognition interface defines the methods (exposed as server actions)
    /// connecting to Amazon Rekognition Service
    /// </summary>
    [OSInterface(Description = "Connector to Amazon Rekognition service", Name = "AmazonRekcognition_BBE_ExternalLogic", IconResourceName = "psn.PH.AWSRekIcon.png")]
    public interface IAmazonRekognition
    {
        /// <summary>
        /// Extract a list of labels from an image.
        /// </summary>
        [OSAction(Description = "Detect and extract labels from an image", ReturnName = "JSONResponse")]
        public string detectLabels_ext(Authenticationinfo authInfo, string bas64Image, int maxLabels, int minConfidence);
        /// <summary>
        /// Extract a list of face details from an image.
        /// </summary>
        [OSAction(Description = "Detect and extract faces details from an image", ReturnName = "JSONResponse")]
        public string detectFaces_ext(Authenticationinfo authInfo, string bas64Image);
        /// <summary>
        /// Detect unsafe or inappropriate content in an image.
        /// </summary>
        [OSAction(Description = "Detect moderation labels (unsafe or inappropriate content) in an image", ReturnName = "JSONResponse")]
        public string detectModerationLabels_ext(Authenticationinfo authInfo, string bas64Image, int minConfidence);
    }
}
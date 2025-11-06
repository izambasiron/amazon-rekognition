using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using PH.Structures;

namespace PH
{

    public class Rekognition : IAmazonRekognition
    {

        /// <summary>
        /// Detect labels.
        /// </summary>

        private AmazonRekognitionClient getClient(Authenticationinfo authInfo)
        {
            AmazonRekognitionClient _rekognitionClient = new AmazonRekognitionClient(authInfo.AwsAccessKeyId, authInfo.awsSecretAccessKey);
            return _rekognitionClient;
        }


        /// <summary>
        /// Detect labels 
        /// </summary>
        /// <param name="autoInfo"></param>
        /// <param name="bas64Image"></param>
        /// <param name="maxLabels"></param>
        /// <param name="minConfidence"></param>
        public string detectLabels_ext(Authenticationinfo authInfo, string bas64Image, int maxLabels, int minConfidence)
        {
            var result = DetectLabels(authInfo, bas64Image, maxLabels, minConfidence);
            return result.Result;
        }


        private Amazon.Rekognition.Model.Image getImageFromBase64(string bas64Image)
        {
            Amazon.Rekognition.Model.Image image = new Amazon.Rekognition.Model.Image();
            byte[] encodedBytes = Convert.FromBase64String(bas64Image);
            MemoryStream memoryStream = new MemoryStream(encodedBytes);
            image.Bytes = memoryStream;
            return image;
        }

        private async Task<string> DetectLabels(Authenticationinfo authInfo, string bas64Image, int maxLabels, int minConfidence)
        {
            Amazon.Rekognition.Model.Image image = getImageFromBase64(bas64Image);
            DetectLabelsRequest detectlabelsRequest = new DetectLabelsRequest()
            {
                Image = image,
                MaxLabels = maxLabels,
                MinConfidence = minConfidence
            };

            AmazonRekognitionClient _rekognitionClient = getClient(authInfo); // RegionEndpoint.GetBySystemName(authInfo.AwsRegion));
            var detectLabelsResponse = await _rekognitionClient.DetectLabelsAsync(detectlabelsRequest);
            var result = System.Text.Json.JsonSerializer.Serialize(detectLabelsResponse);
            return result;
        }


        public string detectFaces_ext(Authenticationinfo authInfo, string bas64Image)
        {
            var result = DetectFaces(authInfo, bas64Image);
            return result.Result;
        }

        /// <summary>
        /// Detect faces. Create a copy of original image with faces highlighted.
        /// </summary>
        /// <param name="autoInfo"></param>
        /// <param name="bas64Image"></param>

        private async Task<string> DetectFaces(Authenticationinfo authInfo, string bas64Image)
        {
            Amazon.Rekognition.Model.Image image = getImageFromBase64(bas64Image);
            AmazonRekognitionClient _rekognitionClient = getClient(authInfo); // RegionEndpoint.GetBySystemName(authInfo.AwsRegion));
            var detectFacesRequest = new DetectFacesRequest
            {
                Attributes = new List<String>() { "ALL" },
                Image = image
            };

            var detectFacesResponse = await _rekognitionClient.DetectFacesAsync(detectFacesRequest);
            var result = System.Text.Json.JsonSerializer.Serialize(detectFacesResponse);
            return result;
        }


        public string detectModerationLabels_ext(Authenticationinfo authInfo, string bas64Image, int minConfidence)
        {
            var result = DetectModerationLabels(authInfo, bas64Image, minConfidence);
            return result.Result;
        }

        /// <summary>
        /// Detect moderation labels (unsafe or inappropriate content) in an image.
        /// </summary>
        /// <param name="authInfo"></param>
        /// <param name="bas64Image"></param>
        /// <param name="minConfidence"></param>
        private async Task<string> DetectModerationLabels(Authenticationinfo authInfo, string bas64Image, int minConfidence)
        {
            Amazon.Rekognition.Model.Image image = getImageFromBase64(bas64Image);
            AmazonRekognitionClient _rekognitionClient = getClient(authInfo);
            var detectModerationLabelsRequest = new DetectModerationLabelsRequest
            {
                Image = image,
                MinConfidence = minConfidence
            };

            var detectModerationLabelsResponse = await _rekognitionClient.DetectModerationLabelsAsync(detectModerationLabelsRequest);
            var result = System.Text.Json.JsonSerializer.Serialize(detectModerationLabelsResponse);
            return result;
        }
    }
}
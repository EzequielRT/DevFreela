﻿using MediatR;

namespace DevFreela.Application.Commands.CommentCommands.CreateComment
{
    public class CreateCommentCommand : IRequest<bool>
    {
        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }
    }
}